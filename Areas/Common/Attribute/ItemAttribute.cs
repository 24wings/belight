using System;
using System.Linq;
using Wings.Base.Common.DTO;

namespace Wings.Base.Common.Attrivute
{
    /// <summary>
    /// 表单特性
    /// </summary>
    public class ItemAttribute : Attribute
    {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
        /// <summary>
        /// 编辑类型
        /// </summary>
        /// <value></value>
        public EditorType editorType { get; set; } = EditorType.dxTextBox;
        /// <summary>
        /// 数据字段
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }

        /// <summary>
        /// 表单附加选项
        /// </summary>
        /// <value></value>
        public EditorOptions editorOptions { get; set; }

    }
    /// <summary>
    /// 表单控件类型
    /// </summary>
    public enum EditorType
    {
        ///<summary>
        ///自动补全
        ///</summary>
        dxAutocomplete,
        ///<summary>
        /// 日历
        ///</summary>
        dxCalendar,
        ///<summary>
        ///勾选
        ///</summary>
        dxCheckBox,
        ///<summary>
        ///颜色选择器
        ///</summary>
        dxColorBox,
        ///<summary>
        ///日期选择器
        ///</summary>
        dxDateBox,
        ///<summary>
        ///下拉
        ///</summary>
        dxDropDownBox,
        ///<summary>
        ///数据查询
        ///</summary>
        dxLookup,
        ///<summary>
        /// 数字框
        ///</summary>
        dxNumberBox,
        ///<summary>
        /// 单选组
        ///</summary>
        dxRadioGroup,
        ///<summary>
        /// 区间
        ///</summary>
        dxRangeSlider,
        ///<summary>
        /// 选择box
        ///</summary>
        dxSelectBox,
        ///<summary>
        /// 区间
        ///</summary>
        dxSlider,
        ///<summary>
        /// 开关
        ///</summary>

        dxSwitch,
        ///<summary>
        /// 标签
        ///</summary>

        dxTagBox,
        ///<summary>
        /// 文本域
        ///</summary>

        dxTextArea,
        ///<summary>
        /// 文本框
        ///</summary>

        dxTextBox,
        ///<summary>
        /// 引用树
        ///</summary>

        wsRefTree

    }
}