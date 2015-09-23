/// <reference path="calculationContext.js" />

function CheckViewModel()
{
    // PRIVATE
    m_name = "NoName";
    m_checkValue = 0.0;
    m_calulationContext = CalculationContextGetSet(1, 1, "eBrief");
    m_isOn = true;

    // INTERFACE
    this.Set_name = function (name)
    {
        m_name = name;
    }
    this.Get_name = function ()
    {
        return m_name;
    }
    this.Set_checkValue = function (checkValue)
    {
        m_checkValue = checkValue;
    };
    this.Get_checkValue = function ()
    {
        return m_checkValue;
    };
    this.Set_calulationContext = function (calulationContext)
    {
        m_calulationContext = calulationContext;
    };
    this.Get_calulationContext = function ()
    {
        return m_calulationContext;
    };
    this.Set_isOn = function (isOn)
    {
        m_isOn = isOn;
    };
    this.Get_isOn = function ()
    {
        return m_isOn;
    };

}

function CheckViewModelGetSet()
{
    var viewModel = new CheckViewModel();
    Object.defineProperty(viewModel, "name", {
        get: function () { return this.Get_name() },
        set: function (value) { this.Set_name(value) }
    });
    Object.defineProperty(viewModel, "checkValue", {
        get: function () { return this.Get_checkValue() },
        set: function (value) { this.Set_checkValue(value) }
    });
    Object.defineProperty(viewModel, "calulationContext", {
        get: function () { return this.Get_calulationContext() },
        set: function (value) { this.Set_calulationContext(value) }
    });
    Object.defineProperty(viewModel, "isOn", {
        get: function () { return this.Get_isOn() },
        set: function (value) { this.Set_isOn(value) }
    });
    return viewModel;
}