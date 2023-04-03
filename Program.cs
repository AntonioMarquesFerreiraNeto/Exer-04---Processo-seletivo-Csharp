using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro {
    internal class Program {
        static void Main(string[] args) {
            
            //Declarando uma lista de objetos financeiros e populando as mesmas de forma dinâmica. 
            List<Financeiro> financeiros = new List<Financeiro>();
            for (int c = 0; c < 10; c++) {
                Financeiro financeiro = new Financeiro();
                financeiro.Id = c + 3;
                financeiro.ValorFaturamento = 3220 * c;
                financeiro.DayDateFatu = DateTime.Now.AddMonths(c);
                financeiros.Add(financeiro);
            }
            //Listando a lista na interface (console).
            foreach (var financeiro in financeiros) {
                Console.WriteLine("...");
                Console.WriteLine($"Id: {financeiro.Id}\nFaturamento: {financeiro.ValorFaturamento.Value.ToString("C2")}\nDia do faturamento: {financeiro.DayDateFatu.Value.ToString("dd/MM/yyyy")}");
                Console.WriteLine("...");
            }

            Console.WriteLine("\n<>Dados<>");
            GetFinanceiroMenorOrMairVal(financeiros);
            GetFinanceiroRelatorios(financeiros);
        }


        static void GetFinanceiroMenorOrMairVal(List<Financeiro> financeiros) {
            double? maior = 0, menor = 0;
            int? idSelectMaior = null, idSelectMenor = null;
            foreach (var financeiro in financeiros) {
                if (financeiro.ValorFaturamento >= maior) {
                    idSelectMaior = financeiro.Id;
                    maior = financeiro.ValorFaturamento;
                }
            }
            menor = maior;
            foreach (var financeiro in financeiros) {
                if (financeiro.ValorFaturamento <= menor && financeiro.ValorFaturamento != 0) {
                    idSelectMenor = financeiro.Id;
                    menor = financeiro.ValorFaturamento;
                }
            }
            if (idSelectMaior == null || idSelectMenor == null) {
                Console.WriteLine("\n\nDesculpe, nenhum dia teve faturamento!\n");
            }
            else {
                Financeiro financeiroSelectMin = financeiros.FirstOrDefault(x => x.Id == idSelectMenor);
                Financeiro financeiroSelectMax = financeiros.FirstOrDefault(x => x.Id == idSelectMaior);
                Console.WriteLine($"O menor faturamento é de {financeiroSelectMin.ValorFaturamento.Value.ToString("C2")} do dia {financeiroSelectMin.DayDateFatu.Value.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"O maior faturamento é de {financeiroSelectMax.ValorFaturamento.Value.ToString("C2")} do dia {financeiroSelectMax.DayDateFatu.Value.ToString("dd/MM/yyyy")}");
            }

        }

        static void GetFinanceiroRelatorios(List<Financeiro> financeiros) {
            double? soma = 0, mediaFinan;
            foreach (var item in financeiros) {
                if (!string.IsNullOrEmpty(item.ValorFaturamento.ToString()) && item.ValorFaturamento > 0) {
                    soma += item.ValorFaturamento;
                }
            }
            mediaFinan = soma / financeiros.Count;
            List<Financeiro> financeiroAcimaMedia = new List<Financeiro>();
            foreach (var item in financeiros) {
                if (item.ValorFaturamento > mediaFinan) {
                    financeiroAcimaMedia.Add(item);
                }
            }
            Console.WriteLine($"A média de faturamento diária é: {mediaFinan.Value.ToString("C2")}");
            Console.WriteLine($"O número de dias de faturamentos acima da média é de: {financeiroAcimaMedia.Count}\n\n");
        }
    }
}
