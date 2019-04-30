using System;
using System.Linq.Expressions;

namespace ServiceTeacher.Service.Domain.Specification
{
    /// <summary>
    /// Base interface of specification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        Expression<Func<T, bool>> ToExpression();
    }
}
