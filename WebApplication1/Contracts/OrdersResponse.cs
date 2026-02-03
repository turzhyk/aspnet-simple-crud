namespace WebApplication1.Contracts
{
    public record OrdersResponse
    (
        Guid id,
            string Desc,
            decimal Price,
            string AssignedTo

    );
}
