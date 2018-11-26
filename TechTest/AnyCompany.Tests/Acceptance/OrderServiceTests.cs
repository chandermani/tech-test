using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    [Collection("AnyCompany Database collection")]
    public class OrderServiceTests
    {
        private readonly AnyCompanyDBFixture dbFixture;
        OrderService _target;

        public OrderServiceTests(AnyCompanyDBFixture dbFixture)
        {
            this.dbFixture = dbFixture;
        }

        [Fact]
        public void Should_place_an_order_with_amount_and_customer()
        {
            _target = Build();

            var result = _target.PlaceOrder(new Order() { OrderId = 1, Amount = 100 }, dbFixture.OtherCustomer.CustomerId);

            result.Should().BeTrue();
        }

        [Fact]
        public void Should_set_VAT_for_UK_customer()
        {
            _target = Build();

            Order order = new Order() { OrderId=2,Amount = 132 };

            var result = _target.PlaceOrder(order, dbFixture.UKCustomer.CustomerId);

            result.Should().BeTrue();

            order.VAT.Should().Be(0.2);
        }


        [Fact]
        public void Should_not_set_VAT_for_non_UK_customer()
        {
            _target = Build();

            Order order = new Order() { OrderId = 3, Amount = 132 };

            var result = _target.PlaceOrder(order, dbFixture.OtherCustomer.CustomerId);

            result.Should().BeTrue();

            order.VAT.Should().Be(0);
        }

        [Fact]
        public void Should_not_create_order_when_amount_is_zero()
        {
            _target = Build();

            var result = _target.PlaceOrder(new Order() { OrderId = 4 }, dbFixture.OtherCustomer.CustomerId);

            result.Should().BeFalse();
        }

        private OrderService Build()
        {
            return new OrderService(new CustomerRepositoryShim(), new OrderRepository(new AnyCompany.Store.AnyCompanyDBContext()));
        }
    }
}