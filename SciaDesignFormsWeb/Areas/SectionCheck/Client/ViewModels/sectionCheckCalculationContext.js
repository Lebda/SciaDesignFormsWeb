function CalculationContext(clcID, combiID, outPutType)
{
    // PRIVATE
    this.m_clcID = clcID;
    this.m_combiID = combiID;
    this.m_outPutType = outPutType;

    // INTERFACE
}

function CalculationContextGetSet(clcID, combiID, outPutType)
{
    var viewModel = new CalculationContext(clcID, combiID, outPutType);
    Object.defineProperty(viewModel, "clcID", {
        get: function () { return this.m_clcID },
        set: function (value) { this.m_clcID = value }
    });
    Object.defineProperty(viewModel, "combiID", {
        get: function () { return this.m_combiID },
        set: function (value) { this.m_combiID = value }
    });
    Object.defineProperty(viewModel, "outPutType", {
        get: function () { return this.m_outPutType },
        set: function (value) { this.m_outPutType = value }
    });
    return viewModel;
}