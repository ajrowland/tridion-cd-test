using System;
using System.Globalization;
using System.Configuration;
using Tridion.ContentDelivery.DynamicContent.Query;

namespace TridionCILTest
{
    class Program
    {
        static void Main()
        {
            foreach (string cultureCode in ConfigurationManager.AppSettings["cultures"].Split(','))
            {
                runTest(cultureCode);
            }

            Console.ReadKey();
        }

        private static void runTest(string culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);

            Console.Write("CurrentCulture is {0}. Result: ", CultureInfo.CurrentCulture.Name);

            Criteria allCriteria = CriteriaFactory.And(new ItemTypeCriteria(64), new PageURLCriteria(ConfigurationManager.AppSettings["pageUrl"]));
            allCriteria.AddCriteria(new PublicationCriteria(int.Parse(ConfigurationManager.AppSettings["publicationId"])));

            Query pageQuery = new Query();

            pageQuery.Criteria = allCriteria;

            string[] resultUris = pageQuery.ExecuteQuery();

            if (resultUris.Length > 0)
            {
                foreach (string uri in resultUris)
                {
                    Console.WriteLine("{0}\n", uri);
                }
            }
            else
            {
                Console.WriteLine("NO RESULTS\n");
            }
        }
    }
}
