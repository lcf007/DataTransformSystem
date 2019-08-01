using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataTransformSystem
{
    public static class DataTransform
    {
        public static AccountStandard CreateAccountStandard(AccountAction accountInput, string[] fields)
        {
            try
            {
                var accountStandard = new AccountStandard();
                for (var i = 0; i < fields.Length; i++)
                {
                    if (accountInput.Actions?[i] != null)
                        accountInput.Actions[i](accountStandard, fields[i]);
                }

                if (!accountStandard.Validation())
                    accountStandard = null;

                return accountStandard;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return null;
            }
        }

        public static void TransFile(string inFileName, FileType fileType, bool hasHeader, string[] header=null)
        {
            var outFileName = inFileName.Replace(".csv", "_converted.csv");
            var logFileName = inFileName.Replace(".csv", "_log.txt");
            var lineNo = 0;
            var failedNo = 0;
            using (var logStreamWriter = new StreamWriter(logFileName))
            {
                logStreamWriter.WriteLine($"Started to transform data from file: {inFileName}");
                if (hasHeader == false && header == null)
                {
                    logStreamWriter.WriteLine($"Header is important for convert, it must in file or in parameters");
                    return;
                }

                using (var inStreamWriter = new StreamReader(inFileName))
                {
                    using (var outStreamWriter = new StreamWriter(outFileName))
                    {
                        outStreamWriter.WriteLine("AccountCode,Name,Type,Open Date,Currency");
                        lineNo++;
                        var readLine = inStreamWriter.ReadLine();
                        var accountAction = new AccountAction();
                        if (hasHeader && readLine != null)
                        {
                            var headerFields = readLine.Split(',');
                            accountAction.MapActions(headerFields);
                            lineNo++;
                            readLine = inStreamWriter.ReadLine();
                        }
                        else
                        {
                            accountAction.MapActions(header);
                        }

                        while (readLine != null)
                        {
                            var fields = readLine.Split(',');

                            var account = CreateAccountStandard(accountAction, fields);
                            if (account != null)
                            {
                                outStreamWriter.WriteLine(account.ToString());
                            }
                            else
                            {
                                failedNo++;
                                logStreamWriter.WriteLine($"Failed, Wrong format in line: {lineNo}: {string.Join(",",fields)}");
                            }

                            lineNo++;
                            readLine = inStreamWriter.ReadLine();
                        }
                    }
                }

                logStreamWriter.WriteLine($"Finished to transform data to file: {outFileName}");
                logStreamWriter.WriteLine($"HasHeader: {hasHeader.ToString()}, Succeed line: {lineNo - failedNo - 1}, Failed: {failedNo}, Total: {lineNo - 1}.");
                logStreamWriter.WriteLine($"----------------------END---------------------");
            }


        }
    }
}
