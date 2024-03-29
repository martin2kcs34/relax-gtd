using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Relax.Infrastructure.Helpers
{
    /// <summary>
    /// INotifyPropertyChanged helper that does not require a base class. Adds an extension method to the event itself, and only requires implement INotifyPropertyChanged.
    /// </summary>
    /// <example>
    /// public class TestVM : INotifyPropertyChanged
    /// {
    ///     public event PropertyChangedEventHandler PropertyChanged;
    ///     private string _name;
    ///     public string Name
    ///     {
    ///         get { return _name; }
    ///         set
    ///         {
    ///             _name = value;
    ///             PropertyChanged.Raise(x=>Name);
    ///         }
    ///     }
    /// }
    /// </example>
    [NoCoverage]
    public static class PropertyHelper
    {
        public static void Raise(this PropertyChangedEventHandler handler, Expression<Func<object, object>> member)
        {
            if (handler != null)
            {
                MemberExpression body;

                var convert = member.Body as UnaryExpression;
                if (convert != null)
                    body = (MemberExpression) convert.Operand;
                else
                    body = (MemberExpression) member.Body;

                var vmExpression = (ConstantExpression) body.Expression;
                LambdaExpression vmlambda = Expression.Lambda(vmExpression);
                Delegate vmFunc = vmlambda.Compile();
                object vm = vmFunc.DynamicInvoke();

                string propertyName = body.Member.Name;
                var e = new PropertyChangedEventArgs(propertyName);
                handler(vm, e);
            }
        }
    }
}