using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    public class OrderServiceTests
    {
        OrderService _target;

        [Fact]
        public void Should_place_an_order_for_customer()
        {
            _target = Build();
            
            var result = _target.PlaceOrder(new Order() { }, 1213);

            result.Should().BeTrue();
        }

        private OrderService Build()
        {
            return new OrderService();
        }
    }
}
