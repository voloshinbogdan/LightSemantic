using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PascalABCCompiler.SyntaxTree;

namespace PascalABCCompiler.LightSemantic
{
    public class InformationCollector : WalkingVisitorNew
    {
        public InformationContainer information;
       // Stack<string> namebuffer;

        public InformationCollector()
        {
            information = new InformationContainer();
            //namebuffer = new Stack<string>();
        }


        public override void visit(var_def_statement _var_def_statement)
        {
            base.visit(_var_def_statement);

            foreach (var variable in _var_def_statement.vars.idents)
	        {
                information.nameController.AddVariable(variable.name, "" + _var_def_statement.vars_type);
	        }
        }

        public override void visit(program_module _program_module)
        {
            ProcessNode(_program_module[0]);
            ProcessNode(_program_module[1]);
            ProcessNode(_program_module.program_block.defs);
            information.nameController.PushNameSpace("Program");
            ProcessNode(_program_module.program_block.program_code);
            information.nameController.PopNameSpace();
            ProcessNode(_program_module[3]);
        }

        public override void visit(procedure_definition _procedure_definition)
        {
            procedure_header _procedure_header = _procedure_definition.proc_header;

            function_header _function_header = _procedure_header as function_header;
            if (_function_header != null)
            {
                information.nameController.AddProcedure(
                    _procedure_header.name.meth_name.name,
                    _procedure_header.parameters.params_list.Select(param => "(" + param.idents.idents.Count + ") : " + param.vars_type.ToString()).ToList(),
                    _function_header.return_type.ToString());
            }
            else
                information.nameController.AddProcedure(
                    _procedure_header.name.meth_name.name,
                    _procedure_header.parameters.params_list.Select(param => "(" + param.idents.idents.Count + ") : " + param.vars_type.ToString()).ToList());

            information.nameController.PushNameSpace(_procedure_header.name.meth_name.name);
            if (_function_header != null)
            {
                information.nameController.AddVariable("Result", "" + _function_header.return_type);
            }
            foreach (var param in _procedure_header.parameters.params_list)
	        {
                foreach (var variable in param.idents.idents)
                {
                    information.nameController.AddVariable(variable.name, "" + param.vars_type);
                }
	        }
            base.visit(_procedure_definition);
            information.nameController.PopNameSpace();
        }

        public override void visit(for_node _for_node)
        {
            information.nameController.PushNameSpace("#FOR");
            base.visit(_for_node);
            information.nameController.PopNameSpace();
        }

        public override void visit(function_lambda_definition _function_lambda_definition)
        {
            information.nameController.PushNameSpace(_function_lambda_definition.lambda_name);
            base.visit(_function_lambda_definition);
            information.nameController.PopNameSpace();
        }
    }
}
