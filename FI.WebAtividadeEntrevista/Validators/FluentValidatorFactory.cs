using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Validators
{
    public class FluentValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static FluentValidatorFactory()
        {
            validators.Add(typeof(IValidator<ClienteModel>), new ClienteValidator());
            validators.Add(typeof(IValidator<BeneficiarioModel>), new BeneficiarioValidator());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}