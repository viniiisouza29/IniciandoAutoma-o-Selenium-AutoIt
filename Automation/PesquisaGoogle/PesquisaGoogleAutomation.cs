using AutomationLib.Automation;
using AutomationLib.Automation.StepIterator;

namespace Automation.PesquisaGoogle
{
    public class PesquisaGoogleAutomation : WebAutomation
    {
        private const string GOOGLE_URL = "https://www.google.com";
        private const string NAME_SEARCH_FIELD = "q";
        private const string NAME_SEARCH_BUTTON = "btnK";
        private const string XPATH_GOOGLE_RESULTS = "//div[@id='rso']/div[contains(@class, 'g')]//h3";
        private const string XPATH_GOOGLE_LINK = "//div[@id='rso']//div[contains(@class, 'g')]//h3/ancestor::a";

        public PesquisaGoogleAutomation(IWebAutomation automation) : base(automation)
        {
        }

        public void Pesquisar(string texto)
        {
            var steps = new StepIterator();
            steps
                .OpenUrl(GOOGLE_URL)
                .WaitForElement(By.Name(NAME_SEARCH_FIELD), TimeSpan.FromSeconds(10))
                .SetValue(By.Name(NAME_SEARCH_FIELD), texto)
                .ElementExists(By.Name(NAME_SEARCH_BUTTON), (exists) =>
                {
                    var iterator = new StepIterator();

                    if (exists)
                    {
                        iterator
                            .Try(i => i.Click(By.Name(NAME_SEARCH_BUTTON)), 
                                (exception, i) => 
                                {
                                    i.SendKey(By.Name(NAME_SEARCH_FIELD), ConsoleKey.Enter);
                                });
                    }
                    else
                    {
                        iterator
                            .SendKey(By.Name(NAME_SEARCH_FIELD), ConsoleKey.Enter);
                    }

                    _automation.Execute(iterator);
                });

            _automation.Execute(steps);
        }

        public List<(string Nome, string Link)> ObterLinks()
        {
            var resultado = new List<(string, string)>();

            var steps = new StepIterator();
            steps
                .ForEachElement(
                    By.XPath(XPATH_GOOGLE_RESULTS),
                    (i) =>
                    {
                        var nome = string.Empty;
                        var link = string.Empty;
                        
                        var resultIterator = new StepIterator();
                        resultIterator
                            .GetText(By.XPath($"({XPATH_GOOGLE_RESULTS})[{i + 1}]"), x => nome = x)
                            .GetAttribute(By.XPath($"({XPATH_GOOGLE_LINK})[{i + 1}]"), "href", x => link = x);

                        _automation.DisableStepDelay();
                        _automation.Execute(resultIterator);
                        _automation.EnableStepDelay();

                        resultado.Add((nome, link));
                    });

            _automation.Execute(steps);

            return resultado;
        }
    }
}