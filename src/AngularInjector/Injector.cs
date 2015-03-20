using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AngularInjector
{
    public class Injector
    {
        readonly Regex _injectTagRegex = new Regex(@"/\*inject\((?<func>[^)]+)\)\*/");
        private const string FindFunction = @"function\s+{0}\s*\(\s*(?<params>([^ ,.]+)?(\s*,\s*([^ ,.]+)\s*)*)\s*\)";

        public string Inject(string input)
        {
            MatchEvaluator replace = m => Replace(m, input);

            return _injectTagRegex.Replace(input, replace);
        }

        protected string Replace(Match match, string allText)
        {
            var funcName = match.Groups["func"].Value;

            var funcFinder = new Regex(string.Format(FindFunction, funcName));

            var funcMatch = funcFinder.Match(allText);

            var parameters = funcMatch.Groups["params"].Value.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            if (!parameters.Any())
                return match.Value;

            return string.Format("{0}{1}.$inject=[{2}];",
                match.Value,
                funcName,
                string.Join(",", parameters.Select(p=>string.Format("'{0}'", p))));
        }
    }
}
