using System.Text.RegularExpressions;

namespace Routing.CustomConstraint
{
    public class AlphaNumericConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var userName = Convert.ToString(values[routeKey]);

            if (userName == null)
            {
                return false;
            }
            if (userName.Length is >= 3 and <= 15 && Regex.IsMatch(userName, "^[a-zA-Z0-9]+$"))
            {
                return true;
            }

            return false;
        }
    }
}
