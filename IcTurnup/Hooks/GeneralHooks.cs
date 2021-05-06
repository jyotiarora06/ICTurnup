using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace icTurnup.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        private static ScenarioContext scenarioContextObject;
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter hTMLReporter;
        private static ExtentTest feature;
        private static ExtentTest scenario;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            hTMLReporter = new ExtentHtmlReporter(@"/Users/jyotimadan/Documents/IcTurnup/ExtentReports/");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(hTMLReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                scenarioContextObject = scenarioContext;

                scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
        }
        /*
        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock currentScenarioBlock = scenarioContextObject.CurrentScenarioBlock;

            switch(currentScenarioBlock)
            {
                case ScenarioBlock.Given:

                    scenario.CreateNode<Given>(scenarioContextObject.StepContext.StepInfo.Text);
                    break;

                case ScenarioBlock.When:

                    scenario.CreateNode<When>(scenarioContextObject.StepContext.StepInfo.Text);
                    break;

                case ScenarioBlock.Then:

                    scenario.CreateNode<Then>(scenarioContextObject.StepContext.StepInfo.Text);
                    break;

                default:

                    scenario.CreateNode<And>(scenarioContextObject.StepContext.StepInfo.Text);
                    break;
            }
        }
        */

        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock currentScenarioBlock = scenarioContextObject.CurrentScenarioBlock;

            switch (currentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    if(scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);
                       

                    }
                    else
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");
                      
                    }
                    break;

                case ScenarioBlock.When:

                    if(scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<When>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<When>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;

                case ScenarioBlock.Then:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Then>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<Then>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;

                default:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<And>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<And>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {
            // TODO: implement logic that has to run before each scenario step
            // For storing and retrieving scenario-specific data, 
            // the instance fields of the class or the
            //     ScenarioContext.Current
            // collection can be used.
            // For storing and retrieving feature-specific data, the 
            //     FeatureContext.Current
            // collection can be used.
            // Use the attribute overload to specify tags. If tags are specified, the event 
            // handler will be executed only if any of the tags are specified for the 
            // feature or the scenario.
            //     [BeforeStep("mytag")]
        }

     

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            // TODO
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            // TODO
        }



        [AfterScenario]
        public void AfterScenario()
        {
            //TODO
        }

        
        [AfterFeature]
        public static void AfterFeature()
        {
            // TODO: implement logic that has to run after executing each feature
        }

        

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
        }
    }
}
