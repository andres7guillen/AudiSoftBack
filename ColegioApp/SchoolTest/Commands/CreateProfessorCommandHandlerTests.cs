using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using Moq;
using SchoolApplication.Commands.CreateProfessor;
using SchoolDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTest.Commands;

public class CreateProfessorCommandHandlerTests
{
    private readonly Mock<IProfessorRepository> _repositoryMock;
    private readonly CreateProfessorCommandHandler _handler;

    public CreateProfessorCommandHandlerTests()
    {
        _repositoryMock = new Mock<IProfessorRepository>();
        _handler = new CreateProfessorCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Create_Professor_When_Data_Is_Valid()
    {
        // Arrange
        var command = new CreateProfessorCommand("Juan");

        var professor = Professor.Create("Juan").Value;

        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Professor>()))
            .ReturnsAsync(Result.Success(professor));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Professor>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Return_Failure_When_Professor_Is_Invalid()
    {
        // Arrange
        var command = new CreateProfessorCommand("");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Name required", result.Error);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Professor>()), Times.Never);
    }

}
