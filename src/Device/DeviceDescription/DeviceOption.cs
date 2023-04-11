using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public record DeviceOption<T> where T : DeviceOption<T>
    {

        protected static readonly Lazy<Dictionary<string, T>> AllOptions = InitOptions();

        private static Lazy<Dictionary<string, T>> InitOptions()
        {
            return new Lazy<Dictionary<string, T>>(() =>
            {
                return typeof(T)
                    .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(x => x.FieldType == typeof(T))
                    .Select(x => x.GetValue(null))
                    .Cast<T>()
                    .ToDictionary(x => x.name, x => x);
            });
        }

        protected DeviceOption(string name) 
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public string Name { get => name; }


        string name;
    }

    public class DeviceOptions<TKey, TValue> : ICloneable
    { 
        public TValue? this[TKey option]
        {
            get
            {
                try
                {
                    return options[option];
                }
                catch (Exception)
                {
                    throw new ArgumentException($"\"{option}\" - параметр не найден");
                }
            }
            set
            {
                if (options.ContainsKey(option))
                {
                    options[option] = value;
                }
                else
                {
                    throw new ArgumentException($"\"{option}\" - параметр не найден");
                }
            }
        }

        public object Clone()
        {
            return new DeviceOptions<TKey, TValue?>(options);
        }

        private DeviceOptions(Dictionary<TKey, TValue?> options)
        {
            this.options = new(options);
        }
        private DeviceOptions(List<TKey> optionList)
        {
            options = optionList.ToDictionary(op => op, op => default(TValue));
        }

        public static implicit operator DeviceOptions<TKey, TValue?>(List<TKey> optionList)
        {
            return new DeviceOptions<TKey, TValue?>(optionList);
        }

        private Dictionary<TKey, TValue?> options;
    }
}
