using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TesterApp.Program.TestType;

namespace TesterApp
{
    public class ResultAnalyzer
    {
        private readonly List<TestResult> _abpResults;
        private readonly List<TestResult> _standartResults;

        public ResultAnalyzer(List<TestResult> abpResults, List<TestResult> standartResults)
        {
            _abpResults = abpResults;
            _standartResults = standartResults;
        }

        public void AnalyzeResults(int argsTestType)
        {
            double abpInsertAndGetIdAvg = 0,
                abpDeleteAvg = 0,
                abpGetPeopleAvg = 0,
                abpGetConstantAvg = 0,
                stdInsertAndGetIdAvg = 0,
                stdDeleteAvg = 0,
                stdGetPeopleAvg = 0,
                stdGetConstantAvg = 0;
            

            if (argsTestType == (int)Both || argsTestType == (int)WithAbp)
            {
                var errorCount = GetErrorCount(_abpResults);

                abpInsertAndGetIdAvg = GetAvarageSpeed(_abpResults, "InsertAndGetId");
                abpDeleteAvg = GetAvarageSpeed(_abpResults, "Delete");
                abpGetPeopleAvg = GetAvarageSpeed(_abpResults, "GetPeople");
                abpGetConstantAvg = GetAvarageSpeed(_abpResults, "GetConstant");

                LogHelper.Log(
                    "Results: \n\n" +
                    "(WITH ABP)    Avarage duration of InsertAndGetId = " + abpInsertAndGetIdAvg + " seconds. (" + Math.Round(1 / abpInsertAndGetIdAvg, 3) + "/s)\n" +
                    "(WITH ABP)    Avarage duration of Delete = " + abpDeleteAvg + " seconds. (" + Math.Round(1 / abpDeleteAvg, 3) + "/s)\n" +
                    "(WITH ABP)    Avarage duration of GetPeople = " + abpGetPeopleAvg + " seconds. (" + Math.Round(1 / abpGetPeopleAvg, 3) + "/s)\n" +
                    "(WITH ABP)    Avarage duration of GetConstant = " + abpGetConstantAvg + " seconds. (" + Math.Round(1 / abpGetConstantAvg, 3) + "/s)\n"+
                    "Total Error Count = " + errorCount
                );
            }

            if (argsTestType == (int)Both || argsTestType == (int)WithoutAbp)
            {
                var errorCount = GetErrorCount(_standartResults);

                stdInsertAndGetIdAvg = GetAvarageSpeed(_standartResults, "InsertAndGetId");
                stdDeleteAvg = GetAvarageSpeed(_standartResults, "Delete");
                stdGetPeopleAvg = GetAvarageSpeed(_standartResults, "GetPeople");
                stdGetConstantAvg = GetAvarageSpeed(_standartResults, "GetConstant");

                LogHelper.Log(
                    "\n" +
                    "(WITHOUT ABP) Avarage duration of InsertAndGetId = " + stdInsertAndGetIdAvg + " seconds. (" + Math.Round(1 / stdInsertAndGetIdAvg, 3) + "/s)\n" +
                    "(WITHOUT ABP) Avarage duration of Delete = " + stdDeleteAvg + " seconds. (" + Math.Round(1 / stdDeleteAvg, 3) + "/s)\n" +
                    "(WITHOUT ABP) Avarage duration of GetPeople = " + stdGetPeopleAvg + " seconds. (" + Math.Round(1 / stdGetPeopleAvg, 3) + "/s)\n" +
                    "(WITHOUT ABP) Avarage duration of GetConstant = " + stdGetConstantAvg + " seconds. (" + Math.Round(1 / stdGetConstantAvg, 3) + "/s)\n" +
                    "Total Error Count = " + errorCount
                );
            }

            if (argsTestType == (int)Both)
            {
                LogHelper.Log(
                    "\n\n" +
                    "On Method InsertAndGetId => " + CompareSpeeds(abpInsertAndGetIdAvg, stdInsertAndGetIdAvg) + "\n" +
                    "On Method Delete         => " + CompareSpeeds(abpDeleteAvg, stdDeleteAvg) + "\n" +
                    "On Method GetPeople      => " + CompareSpeeds(abpGetPeopleAvg, stdGetPeopleAvg) + "\n" +
                    "On Method GetConstant    => " + CompareSpeeds(abpGetConstantAvg, stdGetConstantAvg)
                );
            }
           
        }


        private double GetAvarageSpeed(List<TestResult> results, string method , bool success = true)
        {
           var successfullResults = results.Where(r=>r.Success == success && r.Method.Contains(method)).ToList();
           return successfullResults.Count > 0 ? Math.Round(successfullResults.Average(sr => sr.Duration.TotalSeconds),5) : 99999;
        }

        private int GetErrorCount(List<TestResult> results)
        {
            return results.Where(r => !r.Success).ToList().Count;
        }

        private string CompareSpeeds(double x, double y, string xType = "With ABP", string yType = "Without ABP")
        {
            var ratio = x >= y ? 1.0-(y / x) : (y / x)-1.0;
            ratio = Math.Round(ratio, 3);

            return x>=y? 
                ""+ xType + ", it is %" + ratio*100 +" slower than " + yType :
                ""+ xType + ", it is %" + ratio*100 + " faster than " + yType;
        }

    }
}
