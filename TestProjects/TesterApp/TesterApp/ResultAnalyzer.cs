using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void AnalyzeResults()
        {
            var abpInsertAndGetIdAvg = GetAvarageSpeed(_abpResults, "InsertAndGetId");
            var abpDeleteAvg = GetAvarageSpeed(_abpResults, "Delete");
            var abpGetPeopleAvg = GetAvarageSpeed(_abpResults, "GetPeople");
            var abpGetConstantAvg = GetAvarageSpeed(_abpResults, "GetConstant");
            var stdInsertAndGetIdAvg = GetAvarageSpeed(_standartResults, "InsertAndGetId");
            var stdDeleteAvg = GetAvarageSpeed(_standartResults, "Delete");
            var stdGetPeopleAvg = GetAvarageSpeed(_standartResults, "GetPeople");
            var stdGetConstantAvg = GetAvarageSpeed(_standartResults, "GetConstant");

            LogHelper.Log(
                "Results: \n\n" +
                "(WITH ABP)    Avarage duration of InsertAndGetId = " + abpInsertAndGetIdAvg + " seconds. (" + Math.Round(1 / abpInsertAndGetIdAvg,3) + "/s)\n" +
                "(WITH ABP)    Avarage duration of Delete = " + abpDeleteAvg + " seconds. (" + Math.Round(1 / abpDeleteAvg, 3) + "/s)\n" +
                "(WITH ABP)    Avarage duration of GetPeople = " + abpGetPeopleAvg + " seconds. (" + Math.Round(1 / abpGetPeopleAvg, 3) + "/s)\n" +
                "(WITH ABP)    Avarage duration of GetConstant = " + abpGetConstantAvg + " seconds. (" + Math.Round(1 / abpGetConstantAvg, 3) + "/s)\n" +
                "\n" +
                "(WITHOUT ABP) Avarage duration of InsertAndGetId = " + stdInsertAndGetIdAvg + " seconds. (" + Math.Round(1 / stdInsertAndGetIdAvg, 3) + "/s)\n" +
                "(WITHOUT ABP) Avarage duration of Delete = " + stdDeleteAvg + " seconds. (" + Math.Round(1 / stdDeleteAvg, 3) + "/s)\n" +
                "(WITHOUT ABP) Avarage duration of GetPeople = " + stdGetPeopleAvg + " seconds. (" + Math.Round(1 / stdGetPeopleAvg, 3) + "/s)\n" +
                "(WITHOUT ABP) Avarage duration of GetConstant = " + stdGetConstantAvg + " seconds. (" + Math.Round(1 / stdGetConstantAvg, 3) + "/s)\n"
            );

            LogHelper.Log(
                "\n\n" +
                "On Method InsertAndGetId => " + CompareSpeeds("With ABP", abpInsertAndGetIdAvg,"Without ABP", stdInsertAndGetIdAvg) + "\n" +
                "On Method Delete => " + CompareSpeeds("With ABP", abpDeleteAvg, "Without ABP", stdDeleteAvg) + "\n" +
                "On Method GetPeople => " + CompareSpeeds("With ABP", abpGetPeopleAvg, "Without ABP", stdGetPeopleAvg) + "\n" +
                "On Method GetConstant => " + CompareSpeeds("With ABP", abpGetConstantAvg, "Without ABP", stdGetConstantAvg)
            );
        }


        public double GetAvarageSpeed(List<TestResult> results, string method , bool success = true)
        {
           var successfullResults = results.Where(r=>r.Success == success && r.Method.Contains(method)).ToList();
           return successfullResults.Count > 0 ? Math.Round(successfullResults.Average(sr => sr.Duration.TotalSeconds),5) : 99999;
        }

        public string CompareSpeeds(string xType, double x, string yType, double y)
        {
            var ratio = x >= y ? x / y : y / x;
            ratio = Math.Round(ratio, 3);

            return x>=y? 
                ""+ yType + ", it is %" + ratio*100 +" faster than " + xType :
                ""+ xType + ", it is %" + ratio * 100 + " faster than " + yType;
        }

    }
}
