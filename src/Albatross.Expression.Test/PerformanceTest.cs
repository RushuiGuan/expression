using Albatross.Expression.Tokens;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Test
{
    [TestFixture]
    public class PerformanceTest
    {
        [TestCase("_F_1653650 +_F_1653653 +_F_1630931 +_F_1621441 +_F_1635085 +_F_1630940 +_F_1656490 +_F_1656876 +_F_1656880 +_F_1658339 +_F_1658707 +_F_1658898 +_F_1658901 +_F_1658903 +_F_1659448 +_F_1666372 +_F_1666390 +_F_1659449 +_F_1671193 +_F_1694869 +_F_1696034 +_F_1699178 +_F_1705424", ExpectedResult = 230)]
        [TestCase("if(_F_1653651 >0,\"تعويض\",if(_F_1653651 <0,\"سحب\",if(_F_1653651 =0,\"لا تعويض و لا سحب \",0)))", ExpectedResult = "تعويض")]
        public object PerformanceTesting(string expression)
        {
            Config.NowFunction.DateTimeKind = DateTimeKind.Utc;
            Config.NowFunction.MinuteInterval = 5;
            Config.NowFunction.SecoundInterval = 0;
            var parser = Factory.Instance.DefaultVariableToken(new FormulaVariableToken()).Create();
            var sw = Stopwatch.StartNew();
            var token = parser.Compile(expression);

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var str = JsonConvert.SerializeObject(token, jsonSerializerSettings);
            var token2 = (IToken)JsonConvert.DeserializeObject(str, jsonSerializerSettings);

            var result = token2.EvalValue(x =>
            {
                return 10;
            });

            sw.Stop();
            Console.WriteLine($"Time took:{sw.ElapsedMilliseconds} ms.");

            return result;
        }

        [Test]
        public void PerformanceTesting2()
        {
            var expressions = new[] {
                "if(_F_1571734 =_F_1571734_V_2f28c1d0z2e2dz4d3dzaa1ez4488489eda55 ,_F_1656264 ,0) ",
                "_F_1619756 * 0.15 ",
                "_F_1619757 *0.15 ",
                "_F_1629691  - _F_1629692 ",
                "  _F_1619757 -_F_1619753 ",
                "_F_1629693  + _F_1629694 ",
                "if(_F_1571734 =_F_1571734_V_5a3086edz66a4z4cf1zba76z9366ba04ffed ,_F_1656280 ,0)",
                "if(_F_1571734 =_F_1571734_V_1453c4e5zbd1ez40a2z8f79z80c1c0f226d7 ,_F_1656353 ,0) ",
                "if(_F_1571734 =_F_1571734_V_20169eb2z133fz4fafza49az0a00e8c10fec ,1000,0) ",
                "_F_1619757 -_F_1619753 ",
                "_F_1619756 -_F_1619753 ",
                "if(_F_1653651 >0,\"تعويض\",if(_F_1653651 <0,\"سحب\",if(_F_1653651 =0,\"لا تعويض و لا سحب \",0)))",
                "if(_F_1571734 =_F_1571734_V_ba2fd00az0decz45d1zac79z0bd258b64da2 ,_F_1621441 +1000,0) ",
                "if(_F_1571734 =_F_1571734_V_2cb79604z833fz4008zbb63z0e27856cfe58 ,_F_1633040 ,0) ",
                "_F_1653650 +_F_1653653 +_F_1630931 +_F_1621441 +_F_1635085 +_F_1630940 +_F_1656490 +_F_1656876 +_F_1656880 +_F_1658339 +_F_1658707 +_F_1658898 +_F_1658901 +_F_1658903 +_F_1659448 +_F_1666372 +_F_1666390 +_F_1659449 +_F_1671193 +_F_1694869 +_F_1696034 +_F_1699178 +_F_1705424 ",
                "if(_F_1571734 =_F_1571734_V_ac91217fzedc0z4400z9a4cz90b52f913d1d ,_F_1633040 ,0) ",
                "if(_F_1666135 =\"تعويض مبلغ بسبب ضعف نت\" or _F_1666135 =\"سحب مبلغ بسبب ضعف نت\",_F_1629695 ,0)",
                "_F_1621440 *_F_1620949 ",
                "_F_1630930 *_F_1630929 ",
                "_F_1656264 +_F_1656280 ",
                "if(_F_1571734 =_F_1571734_V_f5446bdfz4e78z4e57zb7a3z4b29f52c7ecb ,_F_1629695  ,0) ",
                "_F_1656264 +1000",
                "if(_F_1571734 =_F_1571734_V_ba2fd00az0decz45d1zac79z0bd258b64da2 ,_F_1656875 ,0)",
                "if(_F_1571734 =_F_1571734_V_31b374c8z97a6z4ccbz82ecz6265a4509a36 ,_F_1629695  ,0) ",
                "if(_F_1571734 =_F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 ,_F_1671109 ,0)",
                "if(_F_1571734 =_F_1571734_V_5922a372zfff9z48e0z9567z61dd03abdafd ,_F_1633040 ,0) ",
                "if(_F_1571734 =_F_1571734_V_49288407z0fd1z430dz8516z6eda119818b4 ,_F_1619757 *_F_1672050 /100*-1,0) ",
                "if(_F_1571734 =_F_1571734_V_6201bb85z4e65z427dzae79zb37bd1ef0e12 ,_F_1633040 * -1,0) ",
                "if(_F_1571734 =_F_1571734_V_5b001bdbz7673z4fe8zb883z37656f1be232 ,_F_1629695  ,0) ",
                "if(_F_1571734 =_F_1571734_V_d5baf2afz9f6dz4b66za108z91a025e59995   ,_F_1629695 ,if(_F_1571734 =_F_1571734_V_32af4eb4za913z41cfzaeb5z1386d22dd2db ,_F_1629695 ,0)) ",
                "if(_F_1571734 =_F_1571734_V_b27a58a9z301az4278zaca1z9bb66e544b67 ,_F_1633040 * -1+_F_1656002 ,0) ",
                "if(_F_1571734 =_F_1571734_V_51f92b5czbaafz49cfzb9ebzf8dbf1dedc62  ,_F_1633040 * -1,0) ",
                "if(_F_1629695 >0 and _F_1571734 =_F_1571734_V_8b36a691z0720z42d7z8d19zd8f7a8963dbe ,\"تعويض مبلغ بسبب ضعف نت\",if(_F_1629695 <0 and _F_1571734 =_F_1571734_V_8b36a691z0720z42d7z8d19zd8f7a8963dbe , \"سحب مبلغ بسبب ضعف نت\",if(_F_1629695 >0 and _F_1571734 =_F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 ,\"تعويض عمولة الشركة\",if(_F_1629695 <0 and _F_1571734 =_F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 ,\"سحب عمولة الشركة\",if(_F_1629695 >0 and _F_1571734 =_F_1571734_V_d5baf2afz9f6dz4b66za108z91a025e59995 ,\"تعويض مبلغ بسبب تغيير طريق\", if(_F_1629695 <0 and _F_1571734 =_F_1571734_V_d5baf2afz9f6dz4b66za108z91a025e59995 ,\"سحب مبلغ بسبب تغيير طريق\",if(_F_1629695 >0 and _F_1571734 =_F_1571734_V_32af4eb4za913z41cfzaeb5z1386d22dd2db ,\"تعويض مبلغ بسبب ضعف نت وتغيير طريق\",if(_F_1629695 <0 and _F_1571734 =_F_1571734_V_32af4eb4za913z41cfzaeb5z1386d22dd2db ,\"سحب مبلغ بسبب ضعف نت و تغيير طريق\",0))))))))",
                "if(_F_1571734  = _F_1571734_V_8b36a691z0720z42d7z8d19zd8f7a8963dbe ,_F_1666135 ,if(_F_1571734 =  _F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 , _F_1666135 ,if(_F_1571734 =_F_1571734_V_d5baf2afz9f6dz4b66za108z91a025e59995 ,_F_1666135 ,if(_F_1571734 =_F_1571734_V_32af4eb4za913z41cfzaeb5z1386d22dd2db ,_F_1666135  ,if(_F_1571734 =_F_1571734_V_e9d46684zb162z4504zaa68za966a5b59411 ,_F_1700002 ,if(_F_1571734 = _F_1571734_V_81bc23deza32bz4723zb93fz2006e8e403de ,_F_1700002 ,if(_F_1571734 =_F_1571734_V_da00563fzb907z4a2az83b1z9bcc9ff5c065 ,_F_1700002 ,if(_F_1571734 =_F_1571734_V_60ca418fz3753z46a8zaed8zf9f5a5a1999e ,_F_1700002 ,_F_1571734 )))))))) ",
                "_F_1619753 *0.15 ",
                "if(_F_1571734 =_F_1571734_V_8b36a691z0720z42d7z8d19zd8f7a8963dbe ,_F_1656002 ,0) ",
                "if(_F_1571734 =_F_1571734_V_3f50738az3bf4z4416zb6e9z8a457f76226f ,_F_1633040 *-1,0)",
                "if(_F_1629695 >0 and _F_1571734 =_F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 ,\"تعويض عمولة الشركة\",if(_F_1629695 <0 and _F_1571734 =_F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 ,\"سحب عمولة الشركة\",0)) ",
                "if(_F_1670888 =\"تعويض عمولة الشركة\" or _F_1670888 =\"سحب عمولة الشركة\",_F_1629695 ,0)",
                "if(_F_1571734 =_F_1571734_V_d353fd49z7924z4a62z85e8z46b76d883526 ,_F_1671109 ,0) ",
                "Year (_F_1571726 )",
                "month(_F_1571726 )",
                "day(_F_1571726 ) ",
                "_F_1695940 +\" - \"+concat(_F_1690865 ,_F_1690683 ,_F_1691169 ) ",
                "Right (_F_1690644 ,2)",
                "if(_F_1694866 >0,_F_1666138 +\" + \"+\"غرامة مفروضة\",_F_1666138 ) ",
                "_F_1694866  * -1 ",
                "if(_F_1571734 =_F_1571727_V_fbeab08dz394dz4004z8cfdza276485516bc ,_F_1633040 , 0) ",
                "if(_F_1571734 =_F_1571734_V_e9d46684zb162z4504zaa68za966a5b59411 or  _F_1571734 =_F_1571734_V_81bc23deza32bz4723zb93fz2006e8e403de or _F_1571734 =_F_1571734_V_da00563fzb907z4a2az83b1z9bcc9ff5c065  or _F_1571734 =_F_1571734_V_60ca418fz3753z46a8zaed8zf9f5a5a1999e ,_F_1629694 ,0) ",
                "if(_F_1571734 =_F_1571734_V_e9d46684zb162z4504zaa68za966a5b59411 and _F_1629694 > 0 , \"تعويض مبلغ زائد\" , if(_F_1571734 =_F_1571734_V_e9d46684zb162z4504zaa68za966a5b59411 and _F_1629694 < 0,\"سحب مبلغ زائد\", if(_F_1571734 =_F_1571734_V_81bc23deza32bz4723zb93fz2006e8e403de  and _F_1629694 > 0 , \" تعويض مبلغ بسبب ضعف نت\" , if(_F_1571734 =_F_1571734_V_81bc23deza32bz4723zb93fz2006e8e403de   and _F_1629694 < 0,\"سحب مبلغ زائد بسبب ضعف نت\",if(_F_1571734 =_F_1571734_V_da00563fzb907z4a2az83b1z9bcc9ff5c065   and _F_1629694 > 0 , \" تعويض مبلغ بسبب تغيير طريق\" , if(_F_1571734 =_F_1571734_V_da00563fzb907z4a2az83b1z9bcc9ff5c065    and _F_1629694 < 0,\"سحب مبلغ بسبب تغيير طريق\",if(_F_1571734 =_F_1571734_V_60ca418fz3753z46a8zaed8zf9f5a5a1999e    and _F_1629694 > 0 , \" تعويض مبلغ بسبب تغيير طريق و ضعف نت \" , if(_F_1571734 =_F_1571734_V_60ca418fz3753z46a8zaed8zf9f5a5a1999e    and _F_1629694 < 0,\" سحب مبلغ بسبب تغيير طريق وضعف نت\",0)))))))) ",
                "if(_F_1571734 =_F_1571734_V_6e12cbf1zb88bz48d7z9879zae11c00a17f2 ,1000-_F_1629692 ,0)",
                "_F_1691142 +\" - \"+_F_1694868+\" - \"+\"برقم عملية\" ",
            };
            Config.NowFunction.DateTimeKind = DateTimeKind.Utc;
            Config.NowFunction.MinuteInterval = 5;
            Config.NowFunction.SecoundInterval = 0;
            var parser = Factory.Instance.DefaultVariableToken(new FormulaVariableToken()).Create();
            var sw = Stopwatch.StartNew();
            foreach (var expression in expressions)
            {
                sw.Restart();
                var result = parser.Compile(expression).EvalValue(x =>
                {
                    if (new[] { "_F_1571726" }.Contains(x))
                        return DateTime.Now;

                    if (new[] { "_F_1666135", "_F_1670888", "_F_1690644", "_F_1695940", "_F_1690865", "_F_1690683", "_F_1691169" }.Contains(x))
                        return "abcd";


                    return 10;
                });
                Console.WriteLine($"Time took:{sw.ElapsedMilliseconds} ms. {expression}");
            }
        }

        [Test]
        public void PerformanceTesting_1000()
        {
            var variables = new List<string>();
            for (int i = 0; i < 1000; i++)
                variables.Add($"_F_A_{Guid.NewGuid().ToString().Replace("-", "z")}");

            var expression = string.Join(" + ", variables);

            Config.NowFunction.DateTimeKind = DateTimeKind.Utc;
            Config.NowFunction.MinuteInterval = 5;
            Config.NowFunction.SecoundInterval = 0;
            var parser = Factory.Instance.DefaultVariableToken(new FormulaVariableToken()).Create();
            var sw = Stopwatch.StartNew();
            var result = parser.Compile(expression).EvalValue(x =>
            {                
                return 10;
            });
            sw.Stop();
            Console.WriteLine($"Time took:{sw.ElapsedMilliseconds} ms. {expression}");
        }

        public class FormulaVariableToken : VariableToken
        {
            protected string[] VariableNamePatterns = new string[] { @"^\\s*_P_([0-9a-zA-Z_\-\.\'\[\] ]+])_A_([0-9a-zA-Z]+)", VariableNamePattern };

            protected Regex BuildVariableNameRegex(string pattern) => new Regex(pattern,                
                RegexOptions.Singleline |
                RegexOptions.IgnorePatternWhitespace
            );

            public override bool Match(string expression, int start, out int next)
            {
                next = expression.Length;
                if (start < expression.Length)
                {
                    foreach (var pattern in VariableNamePatterns)
                    {
                        var variableNameRegex = BuildVariableNameRegex(pattern);
                        var match = variableNameRegex.Match(expression.Substring(start));
                        if (match.Success)
                        {
                            Name = pattern != VariableNamePattern ? match.Value.Trim() : match.Groups[1].Value;
                            next = start + match.Value.Length;

                            return true;
                        }
                    }
                }
                return false;
            }

            public override IToken Clone()
            {
                return new FormulaVariableToken() { Name = Name };
            }
        }
    }
}