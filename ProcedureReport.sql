CREATE PROCEDURE CalculateRevenueByYear
    @Year INT
AS
BEGIN
    -- Tính doanh thu từng tháng của năm được truyền vào
    SELECT 
        MONTH(exportBillDate) AS [Month],
        SUM(totalCost) AS [Revenue]
    FROM 
        [dbo].[Bill]
    WHERE 
        YEAR(exportBillDate) = @Year
    GROUP BY 
        MONTH(exportBillDate);
END;

GO
CREATE PROCEDURE CalculateRevenueByMonth
    @Month INT,
    @Year INT
AS
BEGIN
    -- Tính doanh thu mỗi ngày của tháng được truyền vào
    SELECT 
        CONVERT(DATE, exportBillDate) AS [Date],
        SUM(totalCost) AS [Revenue]
    FROM 
        [dbo].[Bill]
    WHERE 
        MONTH(exportBillDate) = @Month AND YEAR(exportBillDate) = @Year
    GROUP BY 
        CONVERT(DATE, exportBillDate);
END;