CREATE OR ALTER PROCEDURE dbo.InsertSale
    @stor_id CHAR(4),
    @ord_date DATETIME,
    @qty SMALLINT,
    @payterms VARCHAR(12),
    @title_id CHAR(4),
    @ord_num_out VARCHAR(4) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Generate a 4-digit order number
    DECLARE @ord_num VARCHAR(4);
    SELECT @ord_num = CAST(NEXT VALUE FOR dbo.OrderNumberSeq AS VARCHAR(4));

    -- Insert into sales table
    INSERT INTO dbo.sales (stor_id, ord_num, ord_date, qty, payterms, title_id)
    VALUES (@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id);

    -- Output the generated order number
    SET @ord_num_out = @ord_num;
END;
GO
