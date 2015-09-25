/// <reference path="calculationContext.js" />

function CheckViewModel()
{
    // PRIVATE
    this.m_name = "NoName";
    this.m_checkValue = 0.0;
    this.m_calulationContext = CalculationContextGetSet(1, 1, "eBrief");
    this.m_isOn = true;
    // INTERFACE
}

function CheckViewModelGetSet()
{
    var viewModel = new CheckViewModel();
    Object.defineProperty(viewModel, "name",
    {
        get: function ()
        {
            return this.m_name
        },
        set: function (value)
        {
            this.m_name = value
        }
    });
    Object.defineProperty(viewModel, "checkValue",
    {
        get: function ()
        {
            return this.m_checkValue
        },
        set: function (value)
        {
            this.m_checkValue = value
        }
    });
    Object.defineProperty(viewModel, "isOn",
    {
        get: function ()
        {
            return this.m_isOn
        },
        set: function (value)
        {
            this.m_isOn = value
        }
    });
    Object.defineProperty(viewModel, "calulationContext",
    {
        get: function ()
        {
            return this.m_calulationContext
        },
        set: function (value)
        {
            this.m_calulationContext = value
        }
    });
    return viewModel;
}