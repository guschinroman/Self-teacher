using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Domain.Services.Translators
{
    public class TranslatorInfo
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
        public ITranslator Translator { get; set; }
    }
}
