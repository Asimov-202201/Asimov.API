using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US004
    {
        private static WebDriver webDriver;
        public US004()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [Given(@"el docente se encuentra en su perfil")]
        public void GivenElDocenteSeEncuentraEnSuPerfil()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
            var btnGoToLogin = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div[2]/div/a/span"));
            btnGoToLogin.Click();

            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-76']"));
            tboxEmail.SendKeys("omar@gmail.com");
            
            var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-81']"));
            tboxPassword.SendKeys("alves");
            
            var radiusTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[2]/div/div"));
            radiusTeacher.Click();
            
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span"));
            btnSubmit.Click();
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnProfile = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/header/div/a/span")));
            btnProfile.Click();
        }
        
        [When(@"no ha comenzado sus cursos")]
        public void WhenNoHaComenzadoSusCursos()
        {
            if (webDriver.Url == "http://localhost:8080/profile")
            {
                Console.Write("El docente esta en su perfil");
            }
        }

        [Then(@"visualizará un mensaje “por comenzar” en vez de visualizar un puntaje")]
        public void ThenVisualizaraUnMensajePorComenzarEnVezDeVisualizarUnPuntaje()
        {
            if (webDriver.Url == "http://localhost:8080/profile")
            {
                Console.Write("El docente esta en su perfil");
            }
        }

        [When(@"ya ha avanzado parte de sus cursos")]
        public void WhenYaHaAvanzadoParteDeSusCursos()
        {
            if (webDriver.Url == "http://localhost:8080/profile")
            {
                Console.Write("El docente esta en su perfil");
            }
        }

        [Then(@"visualiza todo el puntaje obtenido hasta la actualidad")]
        public void ThenVisualizaTodoElPuntajeObtenidoHastaLaActualidad()
        {
            if (webDriver.Url == "http://localhost:8080/profile")
            {
                Console.Write("El docente esta en su perfil");
            }
        }

        [When(@"ha completado todos sus cursos")]
        public void WhenHaCompletadoTodosSusCursos()
        {
            if (webDriver.Url == "http://localhost:8080/profile")
            {
                Console.Write("El docente esta en su perfil");
            }
        }

        [Then(@"visualiza todo el puntaje obtenido")]
        public void ThenVisualizaTodoElPuntajeObtenido()
        {
            if (webDriver.Url == "http://localhost:8080/profile")
            {
                Console.Write("El docente esta en su perfil");
            }
        }
    }
}