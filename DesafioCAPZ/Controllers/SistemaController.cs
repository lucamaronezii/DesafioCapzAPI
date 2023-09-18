using DesafioCAPZ.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DesafioCAPZ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SistemaController : ControllerBase
    {
        private static List<object> allData = null;
        private static object lockObject = new object();

        public SistemaController()
        {
            InicializarDados();
        }

        private void InicializarDados()
        {
            if (allData == null)
            {
                lock (lockObject)
                {
                    if (allData == null)
                    {
                        allData = new List<object>();

                        string materialsJsonFilePath = "C:/Users/steye/source/repos/DesafioCAPZ/DesafioCAPZ/data/materials.json";
                        string workforceJsonFilePath = "C:/Users/steye/source/repos/DesafioCAPZ/DesafioCAPZ/data/workforce.json";
                        string salesOrdersJsonFilePath = "C:/Users/steye/source/repos/DesafioCAPZ/DesafioCAPZ/data/sales_orders.json";
                        string purchaseOrdersJsonFilePath = "C:/Users/steye/source/repos/DesafioCAPZ/DesafioCAPZ/data/purchase_orders.json";
                        string equipmentsJsonFilePath = "C:/Users/steye/source/repos/DesafioCAPZ/DesafioCAPZ/data/equipments.json";

                        allData.AddRange(CarregarJson<Materials>(materialsJsonFilePath));
                        allData.AddRange(CarregarJson<Workforce>(workforceJsonFilePath));
                        allData.AddRange(CarregarJson<Sales_orders>(salesOrdersJsonFilePath));
                        allData.AddRange(CarregarJson<Purchase_orders>(purchaseOrdersJsonFilePath));
                        allData.AddRange(CarregarJson<Equipment>(equipmentsJsonFilePath));
                    }
                }
            }
        }

        private List<T> CarregarJson<T>(string filePath)
        {
            string jsonContent = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonContent);
        }

        [HttpPost]
        public void AdicionaMaterial([FromBody] Materials material)
        {
            allData.Add(material);
        }

        [HttpGet("pesquisar")]
        public IActionResult PesquisarPorPalavraChave([FromQuery] string palavraChave)
        {
            if (string.IsNullOrWhiteSpace(palavraChave))
            {
                return BadRequest("A palavra-chave não pode ser vazia.");
            }

            List<object> resultados = new List<object>();

            foreach (var data in allData)
            {
                foreach (var property in data.GetType().GetProperties())
                {
                    var propValue = property.GetValue(data);
                    if (propValue != null && propValue.ToString().Contains(palavraChave, StringComparison.OrdinalIgnoreCase))
                    {
                        resultados.Add(data);
                        break;
                    }
                }
            }

            if (resultados.Count == 0)
            {
                return NotFound("Nenhum resultado encontrado para a palavra-chave fornecida.");
            }

            return Ok(resultados);
        }

        [HttpGet]
        public IActionResult ObterTodosObjetos()
        {
            return Ok(allData);
        }
    }
}