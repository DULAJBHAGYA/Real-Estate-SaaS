#!/bin/bash

echo "🚀 Real Estate SaaS - Full Application Test"
echo "=========================================="

# Check if backend is running
echo "1️⃣ Checking Backend Server..."
if curl -s http://localhost:5052/api/system/health > /dev/null; then
    echo "✅ Backend is running on http://localhost:5052"
else
    echo "❌ Backend is not running. Please start it first:"
    echo "   cd server/RealEstateAPI && dotnet run"
    exit 1
fi

# Check if frontend is running
echo -e "\n2️⃣ Checking Frontend Server..."
if curl -s http://localhost:3000 > /dev/null; then
    echo "✅ Frontend is running on http://localhost:3000"
else
    echo "❌ Frontend is not running. Please start it first:"
    echo "   cd client && npm run dev"
    exit 1
fi

echo -e "\n3️⃣ Testing API Endpoints..."

# Test registration
echo "Testing User Registration..."
REGISTER_RESPONSE=$(curl -s -X POST http://localhost:5052/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Test",
    "lastName": "User",
    "email": "test.user@example.com",
    "password": "TestPass123!",
    "confirmPassword": "TestPass123!"
  }')

if echo "$REGISTER_RESPONSE" | grep -q "token"; then
    echo "✅ Registration endpoint working"
else
    echo "❌ Registration failed: $REGISTER_RESPONSE"
fi

# Test login
echo "Testing User Login..."
LOGIN_RESPONSE=$(curl -s -X POST http://localhost:5052/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test.user@example.com",
    "password": "TestPass123!"
  }')

if echo "$LOGIN_RESPONSE" | grep -q "token"; then
    echo "✅ Login endpoint working"
else
    echo "❌ Login failed: $LOGIN_RESPONSE"
fi

echo -e "\n🎉 Application Test Complete!"
echo "=========================================="
echo "🌐 Frontend: http://localhost:3000"
echo "🔧 Backend API: http://localhost:5052/api"
echo "📚 Swagger UI: http://localhost:5052/swagger"
echo ""
echo "📝 Test the full flow:"
echo "1. Open http://localhost:3000 in your browser"
echo "2. Register a new account"
echo "3. Login with your credentials"
echo "4. View your dashboard"
echo "5. Test the logout button"
