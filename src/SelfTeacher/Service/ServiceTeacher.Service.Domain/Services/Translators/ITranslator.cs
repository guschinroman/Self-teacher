using AutoMapper;
using System.Collections.Generic;

namespace ServiceTeacher.Service.Domain.Services.Translators
{
    public interface ITranslator<TSource, TDestination> : ITranslator
    {
        TDestination Translate(TSource source);

        void Update(TSource source, TDestination destination);

        object Translate(object source);

        void Update(object source, object destination);

        IEnumerable<TDestination> Translate(IEnumerable<TSource> source);
    }

    public interface ITranslator
    {

    }
}
