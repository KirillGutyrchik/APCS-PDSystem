using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public interface IDeviceTreeListItem
    {
        /// <summary>
        /// Текст колонок модели который отображается на дереве
        /// </summary>
        (string FirstColumn, string SecondColumn) DisplayText { get; }

        /// <summary>
        /// Редактируемое содержимой 2-й колонки
        /// </summary>
        string EditText { get; }

        /// <summary>
        /// Можно ли редактировать 2-ю колонку
        /// </summary>
        bool IsEditable { get; }

        /// <summary>
        /// Список значений для выпадающего списка
        /// if null - выпадающего списка нет
        /// </summary>
        List<string>? ComboBoxData { get; }

        /// <summary>
        /// Индекс иконки для строки
        /// </summary>
        IconIndex IconIndex { get; }

        /// <summary>
        /// Дочерние элементы дерева
        /// </summary>
        List<IDeviceTreeListItem>? Items { get; }

        /// <summary>
        /// Подительский элемент дерева
        /// </summary>
        IDeviceTreeListItem? Parent { get; set; }
    }
}
