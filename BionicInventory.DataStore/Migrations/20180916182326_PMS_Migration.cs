using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BionicInventory.DataStore.Migrations
{
    public partial class PMS_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(20)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(20)", nullable: false),
                    TIN = table.Column<string>(type: "varchar(10)", nullable: true),
                    email = table.Column<string>(type: "varchar(45)", nullable: true),
                    type = table.Column<string>(type: "varchar(45)", nullable: false),
                    main_phone = table.Column<string>(type: "varchar(13)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(45)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(45)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ITEM",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(45)", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false),
                    unit = table.Column<string>(type: "varchar(45)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    unit_cost = table.Column<float>(type: "float", nullable: false),
                    weight = table.Column<float>(type: "float", nullable: false),
                    photo = table.Column<string>(nullable: true),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_update = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CLIENT_ID = table.Column<uint>(nullable: false),
                    sub_city = table.Column<string>(type: "varchar(45)", nullable: false),
                    city = table.Column<string>(type: "varchar(45)", nullable: true, defaultValueSql: "'Addis Ababa'"),
                    country = table.Column<string>(type: "varchar(45)", nullable: true, defaultValueSql: "'Ethiopia'"),
                    phone_number = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "fk_ADDRESS_client",
                        column: x => x.CLIENT_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHONE_NUMBER",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CLIENT_ID = table.Column<uint>(nullable: false),
                    number = table.Column<string>(type: "varchar(13)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONE_NUMBER", x => x.ID);
                    table.ForeignKey(
                        name: "fk_PHONE_NUMBER_client",
                        column: x => x.CLIENT_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASE_ORDER",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CLIENT_ID = table.Column<uint>(nullable: false),
                    issued_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    initial_payment = table.Column<float>(nullable: false),
                    payment_amount = table.Column<float>(nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    added_payment = table.Column<float>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_ORDER", x => x.ID);
                    table.ForeignKey(
                        name: "fk_PURCHASE_ORDER_customer",
                        column: x => x.CLIENT_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOCIAL_MEDIA",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CLIENT_ID = table.Column<uint>(nullable: false),
                    address = table.Column<string>(type: "varchar(45)", nullable: false),
                    site = table.Column<string>(type: "varchar(45)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOCIAL_MEDIA", x => x.ID);
                    table.ForeignKey(
                        name: "fk_SOCIAL_MEDIA_client",
                        column: x => x.CLIENT_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTION_ORDER",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ordered_by = table.Column<uint>(nullable: false),
                    description = table.Column<string>(type: "varchar(50)", nullable: true),
                    added_on = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTION_ORDER", x => x.ID);
                    table.ForeignKey(
                        name: "fk_PRODUCTION_ORDERED_BY",
                        column: x => x.ordered_by,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPrice",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<uint>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPrice_ITEM_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ITEM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICE",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PURCHASE_ORDER_ID = table.Column<uint>(nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE", x => x.ID);
                    table.ForeignKey(
                        name: "fk_INVOICE_PO_ID",
                        column: x => x.PURCHASE_ORDER_ID,
                        principalTable: "PURCHASE_ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASE_ORDER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PURCHASE_ORDER_ID = table.Column<uint>(nullable: false),
                    ITEM_ID = table.Column<uint>(nullable: false),
                    quantity = table.Column<uint>(nullable: false),
                    price_per_item = table.Column<float>(nullable: false),
                    added_price_per_item = table.Column<float>(nullable: true, defaultValueSql: "'0'"),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_ORDER_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "fk_OUT_ORDER_LIST_item",
                        column: x => x.ITEM_ID,
                        principalTable: "ITEM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_PURCHASE_ORDER_PO_ID",
                        column: x => x.PURCHASE_ORDER_ID,
                        principalTable: "PURCHASE_ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTION_ORDER_LIST",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PRODUCTION_ORDER_ID = table.Column<uint>(nullable: false),
                    ITEM_ID = table.Column<uint>(nullable: false),
                    quantity = table.Column<uint>(nullable: false),
                    cost_per_item = table.Column<float>(nullable: false),
                    complete = table.Column<bool>(nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTION_ORDER_LIST", x => x.ID);
                    table.ForeignKey(
                        name: "fk_IN_ORDER_LIST_item",
                        column: x => x.ITEM_ID,
                        principalTable: "ITEM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_IN_ORDER_LIST_id",
                        column: x => x.PRODUCTION_ORDER_ID,
                        principalTable: "PRODUCTION_ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICE_PAYMENTS",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    INVOICE_NO = table.Column<uint>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE_PAYMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "fk_INVOICE_PAYMENTS_INVOICE",
                        column: x => x.INVOICE_NO,
                        principalTable: "INVOICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FINISHED_PRODUCT",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ORDER_ID = table.Column<uint>(nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    submitted_by = table.Column<uint>(nullable: false),
                    recieved_by = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FINISHED_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "fk_FINISHED_ORDER_id",
                        column: x => x.ORDER_ID,
                        principalTable: "PRODUCTION_ORDER_LIST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_FINISHED_PRODUCT_recieved_by",
                        column: x => x.recieved_by,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_FINISHED_PRODUCT_submitter",
                        column: x => x.submitted_by,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INVOICE_DETAIL",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_addded = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    date_updated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'CURRENT_TIMESTAMP'"),
                    INVENTORY_ID = table.Column<uint>(nullable: false),
                    INVOICE_NO = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "fk_SALE_DETAIL_INVENTORY_ID",
                        column: x => x.INVENTORY_ID,
                        principalTable: "FINISHED_PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_INVOICE_ID",
                        column: x => x.INVOICE_NO,
                        principalTable: "INVOICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fk_ADDRESS_client_idx",
                table: "ADDRESS",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "TIN_UNIQUE",
                table: "CUSTOMER",
                column: "TIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_FINISHED_ORDER_id_idx",
                table: "FINISHED_PRODUCT",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "fk_FINISHED_PRODUCT_recieved_by_idx",
                table: "FINISHED_PRODUCT",
                column: "recieved_by");

            migrationBuilder.CreateIndex(
                name: "fk_FINISHED_PRODUCT_submitter_idx",
                table: "FINISHED_PRODUCT",
                column: "submitted_by");

            migrationBuilder.CreateIndex(
                name: "PURCHASE_ORDER_ID_UNIQUE",
                table: "INVOICE",
                column: "PURCHASE_ORDER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_SALE_DETAIL_INVENTORY_ID_idx",
                table: "INVOICE_DETAIL",
                column: "INVENTORY_ID");

            migrationBuilder.CreateIndex(
                name: "fk_INVOICE_ID_idx",
                table: "INVOICE_DETAIL",
                column: "INVOICE_NO");

            migrationBuilder.CreateIndex(
                name: "fk_INVOICE_PAYMENTS_INVOICE_idx",
                table: "INVOICE_PAYMENTS",
                column: "INVOICE_NO");

            migrationBuilder.CreateIndex(
                name: "code_UNIQUE",
                table: "ITEM",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrice_ItemId",
                table: "ItemPrice",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "fk_PHONE_NUMBER_client_idx",
                table: "PHONE_NUMBER",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "number_UNIQUE",
                table: "PHONE_NUMBER",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_PRODUCTION_ORDERED_BY_idx",
                table: "PRODUCTION_ORDER",
                column: "ordered_by");

            migrationBuilder.CreateIndex(
                name: "fk_IN_ORDER_LIST_item_idx",
                table: "PRODUCTION_ORDER_LIST",
                column: "ITEM_ID");

            migrationBuilder.CreateIndex(
                name: "fk_IN_ORDER_LIST_id_idx",
                table: "PRODUCTION_ORDER_LIST",
                column: "PRODUCTION_ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "fk_PURCHASE_ORDER_customer_idx",
                table: "PURCHASE_ORDER",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "fk_OUT_ORDER_LIST_item_idx",
                table: "PURCHASE_ORDER_DETAIL",
                column: "ITEM_ID");

            migrationBuilder.CreateIndex(
                name: "fk_OUT_ORDER_LIST_order_idx",
                table: "PURCHASE_ORDER_DETAIL",
                column: "PURCHASE_ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "CLIENT_ID_UNIQUE",
                table: "SOCIAL_MEDIA",
                column: "CLIENT_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "INVOICE_DETAIL");

            migrationBuilder.DropTable(
                name: "INVOICE_PAYMENTS");

            migrationBuilder.DropTable(
                name: "ItemPrice");

            migrationBuilder.DropTable(
                name: "PHONE_NUMBER");

            migrationBuilder.DropTable(
                name: "PURCHASE_ORDER_DETAIL");

            migrationBuilder.DropTable(
                name: "SOCIAL_MEDIA");

            migrationBuilder.DropTable(
                name: "FINISHED_PRODUCT");

            migrationBuilder.DropTable(
                name: "INVOICE");

            migrationBuilder.DropTable(
                name: "PRODUCTION_ORDER_LIST");

            migrationBuilder.DropTable(
                name: "PURCHASE_ORDER");

            migrationBuilder.DropTable(
                name: "ITEM");

            migrationBuilder.DropTable(
                name: "PRODUCTION_ORDER");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");
        }
    }
}
