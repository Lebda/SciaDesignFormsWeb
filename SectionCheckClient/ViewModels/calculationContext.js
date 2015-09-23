function CalculationContext(clcID, combiID, outPutType)
{
    // PRIVATE
    m_clcID = clcID;
    m_combiID = combiID;
    m_outPutType = outPutType;

    // INTERFACE
    this.Set_clcID = function (clcID)
    {
        m_clcID = clcID;
    };
    this.Get_clcID = function ()
    {
        return m_clcID;
    };
    this.Set_combiID = function (combiID)
    {
        m_combiID = combiID;
    };
    this.Get_combiID = function ()
    {
        return m_combiID;
    };
    this.Set_outPutType = function (outPutType)
    {
        m_outPutType = outPutType;
    };
    this.Get_outPutType = function ()
    {
        return m_outPutType;
    };
}

function CalculationContextGetSet(clcID, combiID, outPutType)
{
    var viewModel = new CalculationContext(clcID, combiID, outPutType);
    Object.defineProperty(viewModel, "clcID", {
        get: function () { return this.Get_clcID() },
        set: function (value) { this.Set_clcID(value) }
    });
    Object.defineProperty(viewModel, "combiID", {
        get: function () { return this.Get_combiID() },
        set: function (value) { this.Set_combiID(value) }
    });
    Object.defineProperty(viewModel, "outPutType", {
        get: function () { return this.Get_outPutType() },
        set: function (value) { this.Set_outPutType(value) }
    });
    return viewModel;
}