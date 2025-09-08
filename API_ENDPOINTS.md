# 🚀 Real Estate SaaS - Complete API Endpoints

## 📋 **API Overview**

**Base URL**: `https://localhost:7000/api`  
**Authentication**: JWT Bearer Token  
**Content-Type**: `application/json`

---

## 🔐 **1. Authentication & Users** (`/api/auth`, `/api/users`)

### **Authentication Endpoints**

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/auth/register` | Register new user | ❌ No |
| `POST` | `/api/auth/login` | User login | ❌ No |
| `POST` | `/api/auth/refresh` | Refresh JWT token | ❌ No |
| `POST` | `/api/auth/logout` | Invalidate session | ✅ Yes |
| `POST` | `/api/auth/forgot-password` | Request password reset | ❌ No |
| `POST` | `/api/auth/reset-password` | Reset password with token | ❌ No |

### **User Management Endpoints**

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/users/me` | Get current user profile | ✅ Yes |
| `PUT` | `/api/users/me` | Update current user profile | ✅ Yes |
| `POST` | `/api/users/me/change-password` | Change password | ✅ Yes |
| `GET` | `/api/users/{id}` | Get user by ID | ✅ Admin |
| `DELETE` | `/api/users/{id}` | Delete user | ✅ Admin |

---

## 🏠 **2. Properties** (`/api/properties`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/properties` | Create new property | ✅ Agent |
| `GET` | `/api/properties` | Get all properties (with filters) | ❌ No |
| `GET` | `/api/properties/{id}` | Get property details | ❌ No |
| `PUT` | `/api/properties/{id}` | Update property | ✅ Agent/Owner |
| `DELETE` | `/api/properties/{id}` | Delete property | ✅ Admin/Agent |
| `POST` | `/api/properties/{id}/images` | Upload property images | ✅ Agent |
| `DELETE` | `/api/properties/{id}/images/{imgId}` | Remove property image | ✅ Agent |

### **Property Search Filters**
```
GET /api/properties?city=Colombo&minPrice=100000&maxPrice=300000&type=apartment&bedrooms=3&bathrooms=2&isPetFriendly=true&hasGarage=true&page=1&pageSize=10&sortBy=price&sortDirection=asc
```

---

## 🔍 **3. Search & Recommendations** (`/api/search`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/search` | Full-text property search | ❌ No |
| `POST` | `/api/search/recommendations` | AI-powered recommendations | ✅ Yes |
| `POST` | `/api/search/price-prediction` | AI price prediction | ❌ No |

---

## 📅 **4. Bookings & Appointments** (`/api/bookings`, `/api/agents`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/bookings` | Book property visit | ✅ Yes |
| `GET` | `/api/bookings` | Get my bookings | ✅ Yes |
| `GET` | `/api/bookings/{id}` | Get booking details | ✅ Yes |
| `PUT` | `/api/bookings/{id}` | Update booking | ✅ Yes |
| `DELETE` | `/api/bookings/{id}` | Cancel booking | ✅ Yes |
| `GET` | `/api/agents/{id}/calendar` | Get agent availability | ✅ Yes |
| `GET` | `/api/agents/{id}` | Get agent details | ❌ No |
| `GET` | `/api/agents` | List agents | ❌ No |

---

## 👑 **5. Admin & Management** (`/api/admin`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/admin/users` | List all users | ✅ Admin |
| `GET` | `/api/admin/properties/pending` | Pending property approvals | ✅ Admin |
| `PUT` | `/api/admin/properties/{id}/approve` | Approve property | ✅ Admin |
| `PUT` | `/api/admin/properties/{id}/reject` | Reject property | ✅ Admin |
| `GET` | `/api/admin/analytics` | Platform analytics | ✅ Admin |

---

## 💳 **6. Payments** (`/api/payments`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/payments/checkout` | Create checkout session | ✅ Yes |
| `POST` | `/api/payments/webhook` | Payment webhook | ❌ No |
| `GET` | `/api/payments/history` | Payment history | ✅ Yes |

---

## 🤖 **7. AI/ML Integration** (`/api/ai`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/ai/price-estimate` | AI price estimation | ✅ Yes |
| `POST` | `/api/ai/image-tagging` | Auto-tag images | ✅ Yes |
| `POST` | `/api/ai/chatbot` | Real estate chatbot | ✅ Yes |

---

## 🔧 **8. System & Security** (`/api/system`)

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/system/health` | Health check | ❌ No |
| `GET` | `/api/system/logs` | System logs | ✅ Admin |
| `GET` | `/api/system/audit` | Audit trail | ✅ Admin |

---

## 📝 **Request/Response Examples**

### **User Registration**
```json
POST /api/auth/register
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "SecurePass123!",
  "confirmPassword": "SecurePass123!",
  "phoneNumber": "+1234567890"
}
```

### **Property Search**
```json
GET /api/properties?city=New York&minPrice=500000&maxPrice=1000000&bedrooms=2&bathrooms=2&hasGarage=true&page=1&pageSize=10
```

### **Create Booking**
```json
POST /api/bookings
{
  "propertyId": 123,
  "scheduledDate": "2024-01-15T10:00:00Z",
  "startTime": "10:00:00",
  "endTime": "11:00:00",
  "notes": "First time buyer, interested in financing options",
  "contactPhone": "+1234567890",
  "contactEmail": "buyer@example.com"
}
```

### **AI Price Prediction**
```json
POST /api/ai/price-estimate
{
  "city": "New York",
  "state": "NY",
  "propertyType": "Apartment",
  "bedrooms": 2,
  "bathrooms": 2,
  "squareFootage": 1200,
  "yearBuilt": 2020,
  "hasGarage": true,
  "hasPool": false,
  "hasGarden": true
}
```

---

## 🔒 **Security Features**

- **JWT Authentication** with configurable expiry
- **Role-based Authorization** (Admin, Agent, User)
- **Password Hashing** with ASP.NET Identity
- **Input Validation** with FluentValidation
- **HTTPS/TLS** enforcement
- **Rate Limiting** (to be implemented)
- **Audit Logging** for security events

---

## 📊 **Response Format**

### **Success Response**
```json
{
  "isSuccess": true,
  "data": { ... },
  "message": "Operation completed successfully"
}
```

### **Error Response**
```json
{
  "isSuccess": false,
  "error": "Error message",
  "errors": ["Validation error 1", "Validation error 2"]
}
```

### **Paginated Response**
```json
{
  "items": [...],
  "totalCount": 100,
  "page": 1,
  "pageSize": 10,
  "totalPages": 10
}
```

---

## 🚀 **Getting Started**

1. **Start the API**: `dotnet run --project server/RealEstateAPI`
2. **Access Swagger**: `https://localhost:7000/swagger`
3. **Register User**: `POST /api/auth/register`
4. **Login**: `POST /api/auth/login`
5. **Use JWT Token**: Add `Authorization: Bearer <token>` header

---

## 📈 **Development Phases**

### **Phase 1: MVP** ✅
- Authentication & Users
- Properties CRUD
- Basic Search
- Bookings

### **Phase 2: Security** ✅
- Role-based Authorization
- Input Validation
- Audit Logging
- Health Checks

### **Phase 3: AI & Payments** ✅
- AI Integration Endpoints
- Payment Processing
- Advanced Analytics
- Admin Dashboard

---

**🎯 Total Endpoints: 40+**  
**🔐 Security: Enterprise-grade**  
**🤖 AI-Ready: Future-proof architecture**
