using ColegioDomain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Repositories;
using SchoolData.Context;

namespace SchoolTest.Repositories;

public class ProfessorRepositoryTests
{
    private SchoolDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<SchoolDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new SchoolDbContext(options);
    }

    [Fact]
    public async Task AddAsync_Should_Add_Professor()
    {
        // Arrange
        var context = GetDbContext();
        var repository = new ProfessorRepository(context);

        var professor = Professor.Create("Carlos").Value;

        // Act
        var result = await repository.AddAsync(professor);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(1, context.Professors.Count());
    }

}