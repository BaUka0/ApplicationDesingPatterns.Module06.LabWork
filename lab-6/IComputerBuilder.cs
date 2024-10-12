using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        void SetGPU();
        void SetOS();
        void SetPowerSupply();
        void SetCoolingSystem();
        Computer GetComputer();
    }
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GPU { get; set; }
        public string OS { get; set; }
        public string PowerSupply { get; set; }
        public string CoolingSystem { get; set; }
        public override string ToString()
        {
            return $"Компьютер: CPU - {CPU}, RAM - {RAM}, Накопитель - {Storage}, GPU - {GPU}, ОС - {OS}, Блок питание - {PowerSupply}, Система Охлаждение - {CoolingSystem}";
        }
    }
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU() => _computer.CPU = "Intel i3";
        public void SetRAM() => _computer.RAM = "8GB";
        public void SetStorage() => _computer.Storage = "1TB HDD";
        public void SetGPU() => _computer.GPU = "Integrated";
        public void SetOS() => _computer.OS = "Windows 10";
        public void SetPowerSupply() => _computer.PowerSupply = "350W";
        public void SetCoolingSystem() => _computer.CoolingSystem = "65W";

        public Computer GetComputer() => _computer;
    }

    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU() => _computer.CPU = "Intel i9";
        public void SetRAM() => _computer.RAM = "32GB";
        public void SetStorage() => _computer.Storage = "1TB SSD";
        public void SetGPU() => _computer.GPU = "NVIDIA RTX 3080";
        public void SetOS() => _computer.OS = "Windows 11";
        public void SetPowerSupply() => _computer.PowerSupply = "850W";
        public void SetCoolingSystem() => _computer.CoolingSystem = "350W";

        public Computer GetComputer() => _computer;
    }
    public class GraphicWorkstationBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU() => _computer.CPU = "Intel Xeon";
        public void SetRAM() => _computer.RAM = "64GB";
        public void SetStorage() => _computer.Storage = "2TB SSD";
        public void SetGPU() => _computer.GPU = "NVIDIA RTX 6000";
        public void SetOS() => _computer.OS = "Windows 11 Pro";
        public void SetPowerSupply() => _computer.PowerSupply = "1000W";
        public void SetCoolingSystem() => _computer.CoolingSystem = "600W";

        public Computer GetComputer() => _computer;
    }

    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructComputer()
        {
            _builder.SetCPU();
            _builder.SetRAM();
            _builder.SetStorage();
            _builder.SetGPU();
            _builder.SetOS();
            _builder.SetPowerSupply();
            _builder.SetCoolingSystem();
        }

        public Computer GetComputer()
        {
            return _builder.GetComputer();
        }

        public bool ValidateConfiguration(Computer computer)
        {
            if (computer.CPU.Contains("Xeon") && computer.GPU.Contains("Integrated"))
            {
                Console.WriteLine("Ошибка:  Intel Xeon не имеет встроенную графику.");
                return false;
            }
            if(computer.CPU.Contains("i3") && computer.GPU.Contains("RTX"))
            {
                Console.WriteLine("Ошибка:  RTX избыточна для i3.");
                return false;
            }
            if (computer.CPU.Contains("i9") && computer.GPU.Contains("350W"))
            {
                Console.WriteLine("Ошибка:  Intel i9 требует намного больше энергии чем 350W");
                return false;
            }
            return true;
        }
    }

}
