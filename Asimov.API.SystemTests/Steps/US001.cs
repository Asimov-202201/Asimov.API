using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US001
    {
        private static WebDriver webDriver;
        public US001()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [When(@"seleccione para ver el resumen general")]
        public void WhenSeleccioneParaVerElResumenGeneral()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Resumen General");
            }
        }

        [When(@"es el inicio del año escolar")]
        public void WhenEsElInicioDelAnoEscolar()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Resumen General");
            }
        }

        [Then(@"todos los datos estadísticos comienzan en (.*)\.")]
        public void ThenTodosLosDatosEstadisticosComienzanEn(int p0)
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Resumen General");
            }
        }

        [Then(@"visualizará los diferentes gráficos sobre el progreso de los profesores\.")]
        public void ThenVisualizaraLosDiferentesGraficosSobreElProgresoDeLosProfesores()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Resumen General");
            }
        }

        [When(@"el año escolar ya ha concluído")]
        public void WhenElAnoEscolarYaHaConcluido()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Resumen General");
            }
        }

        [Then(@"visualizará los diferentes gráficos sobre las metas logradas por los profesores\.")]
        public void ThenVisualizaraLosDiferentesGraficosSobreLasMetasLogradasPorLosProfesores()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Resumen General");
            }
        }
    }
}