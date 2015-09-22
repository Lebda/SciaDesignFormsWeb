function CalculationContext(clcID, combiID, outPutType)
{
    // PRIVATE
    m_clcID = clcID;
    m_combiID = combiID;
    m_outPutType = outPutType;

    // INTERFACE
    this.SetclcID = function (clcID)
    {
        m_clcID = clcID;
    }
    this.GetClcID = function (clcID)
    {
        return m_clcID;
    }
    this.SetCombiID = function (combiID)
    {
        m_combiID = combiID;
    }
    this.GetCombiID = function (combiID)
    {
        return m_combiID;
    }
    this.SetOutPutType = function (outPutType)
    {
        m_outPutType = outPutType;
    }
    this.GetOutPutType = function (outPutType)
    {
        return m_outPutType;
    }
}