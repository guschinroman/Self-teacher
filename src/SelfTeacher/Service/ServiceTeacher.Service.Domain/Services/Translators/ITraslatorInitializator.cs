using ServiceTeacher.Service.Domain.Services.Translators;

namespace ServiceTeacher.Service.Domain.Services
{
    public interface ITraslatorInitializator
    {
        void RegisterTranslator<TSource, TDestination>(ITranslator<TSource, TDestination> translator);
        ITranslator<TSource, TDestination> GetTranslator<TSource, TDestination>();
    }
}
