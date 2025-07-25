using BlazorUserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add HttpClient for API calls
builder.Services.AddHttpClient<UserService>();
builder.Services.AddHttpClient<AuthService>();
builder.Services.AddHttpClient<CartService>();
builder.Services.AddHttpClient<ProductService>();
builder.Services.AddHttpClient<CategoryService>();

// Add SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Map SignalR hub
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
