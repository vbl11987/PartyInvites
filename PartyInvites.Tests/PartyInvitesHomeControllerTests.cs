
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Controllers;
using PartyInvites.Models;
using Xunit;

namespace PartyInvites.Tests
{
    public class PartyInvitesHomeControllerTests
    {
        [Fact]
        public void ListActionFilterNonAttendees(){
            //Arrange
            PartyInvitesHomeController controller = new PartyInvitesHomeController(new FakeRepository());

            //Act
            ViewResult result = controller.ListResponses();

            //Assert
            Assert.Equal(2, (result.Model as IEnumerable<GuestResponse>).Count());
        }
    }

    class FakeRepository : IRepository {
        public IEnumerable<GuestResponse> Responses =>
            new List<GuestResponse> {
                new GuestResponse { Name = "Joe", WillAttend = true },
                new GuestResponse { Name = "Chandler", WillAttend = true },
                new GuestResponse { Name = "Ross", WillAttend = false }
            };
        public void AddResponse(GuestResponse response){
            throw new NotImplementedException();
        }
    }
}