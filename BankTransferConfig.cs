using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class BankTransferConfig
{
    class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    class Confirmation
    {
        public string en { get; set; }
        public string threshold { get; set; }
    }

    class Config
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }

        public Config() { }
        public Config(string lang, Transfer transfer, string[] methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    class BankConfig
    {
        public Config config;
        public const String filePath = @"bank_transfer_config.json";
        public BankConfig() 
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }

        }
        public Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }
        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public SetDefault()
        {

        }
    }
}
