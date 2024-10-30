using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class AddCulums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbSuppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbSuppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbSuppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbSuppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbSettings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbSalesInvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbSalesInvoiceItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbSalesInvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbSalesInvoiceItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbSalesInvoiceItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbPurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbPurchaseInvoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbPurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbPurchaseInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbPurchaseInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbPurchaseInvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbPurchaseInvoiceItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbPurchaseInvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbPurchaseInvoiceItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbPurchaseInvoiceItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbItemImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbItemImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbItemImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbItemImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbItemDiscount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbItemDiscount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbItemDiscount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbItemDiscount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbItemDiscount",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCustomers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCashTransacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCashTransacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCashTransacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCashTransacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCashTransacion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbBusinessInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbBusinessInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbBusinessInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbBusinessInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbBusinessInfo",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbSuppliers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbSuppliers");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSuppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbSuppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbSuppliers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbSalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbSalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbSalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbSalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbPurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbPurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbPurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbPurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbPurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbPurchaseInvoiceItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbPurchaseInvoiceItems");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbPurchaseInvoiceItems");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbPurchaseInvoiceItems");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbPurchaseInvoiceItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbItemDiscount");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbItemDiscount");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbItemDiscount");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbItemDiscount");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbItemDiscount");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCustomers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCustomers");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCustomers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCustomers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCustomers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCashTransacion");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCashTransacion");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCashTransacion");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCashTransacion");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCashTransacion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbBusinessInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbBusinessInfo");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbBusinessInfo");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbBusinessInfo");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbBusinessInfo");
        }
    }
}
