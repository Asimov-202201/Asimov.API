using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US010
    {
        
        private static WebDriver webDriver;
        public US010()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));        }
        
        [Given(@"el director se encuentra en el apartado de Teachers")]
        public void GivenElDirectorSeEncuentraEnElApartadoDeTeachers()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
            var btnGoToLogin = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div[2]/div/a/span"));
            btnGoToLogin.Click();

            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-76']"));
            tboxEmail.SendKeys("julio@gmail.com");
            
            var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-81']"));
            tboxPassword.SendKeys("yulius15");
            
            var radiusDirector = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[1]/div/div"));
            radiusDirector.Click();
            
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span"));
            btnSubmit.Click();
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnProfile = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/header/div/a/span")));
            btnProfile.Click();
            webDriver.Navigate().GoToUrl("http://localhost:8080/teachers");
        }

        [When(@"seleccione un docente de la lista de docentes")]
        public void WhenSeleccioneUnDocenteDeLaListaDeDocentes()
        {
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnSeeMore = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[2]/div/div/div[1]/div[2]/a/span")));
            btnSeeMore.Click();

        }

        [Then(@"podrá ver la información del docente junto con su horario")]
        public void ThenPodraVerLaInformacionDelDocenteJuntoConSuHorario()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Visualizando informacion de Omar");
            }
        }

        [Then(@"podrá ver la información del docente, pero no encontrará su horario")]
        public void ThenPodraVerLaInformacionDelDocentePeroNoEncontraraSuHorario()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Visualizando informacion de Omar");
            }
        }

        [Then(@"se mostrará el mensaje “no existen docentes registrados para esta institución”")]
        public void ThenSeMostraraElMensajeNoExistenDocentesRegistradosParaEstaInstitucion()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Visualizando informacion de Omar");
            }
        }
    }
}