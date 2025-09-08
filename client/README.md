# Real Estate SaaS - Frontend Client

A Next.js frontend application for testing the Real Estate SaaS API endpoints.

## Features

- **Authentication Flow**: Register, Login, Logout
- **Responsive Design**: Built with Tailwind CSS
- **JWT Token Management**: Automatic token storage and handling
- **User Dashboard**: Display user information and account status
- **API Integration**: Direct integration with .NET backend

## Tech Stack

- **Next.js 14** - React framework
- **TypeScript** - Type safety
- **Tailwind CSS** - Styling
- **Fetch API** - HTTP requests

## Getting Started

### Prerequisites

- Node.js 18+ 
- Backend server running on `http://localhost:5052`

### Installation

```bash
# Install dependencies
npm install

# Run development server
npm run dev
```

### Available Scripts

- `npm run dev` - Start development server
- `npm run build` - Build for production
- `npm run start` - Start production server
- `npm run lint` - Run ESLint

## API Endpoints Tested

- `POST /api/auth/register` - User registration
- `POST /api/auth/login` - User login  
- `POST /api/auth/logout` - User logout
- `GET /api/users/me` - Get current user (future)

## Project Structure

```
client/
├── src/
│   ├── app/
│   │   ├── globals.css
│   │   ├── layout.tsx
│   │   └── page.tsx
│   └── components/
│       ├── LoginForm.tsx
│       ├── RegisterForm.tsx
│       └── HomePage.tsx
├── public/
└── package.json
```

## Usage

1. **Start the backend server** (in server directory):
   ```bash
   cd server/RealEstateAPI
   dotnet run
   ```

2. **Start the frontend** (in client directory):
   ```bash
   cd client
   npm run dev
   ```

3. **Open browser** to `http://localhost:3000`

4. **Test the flow**:
   - Register a new account
   - Login with credentials
   - View dashboard
   - Logout

## Features Demonstrated

- ✅ **User Registration** - Create new accounts
- ✅ **User Login** - Authenticate users
- ✅ **JWT Token Storage** - Secure token management
- ✅ **User Dashboard** - Display account information
- ✅ **Logout Functionality** - Clear session and tokens
- ✅ **Error Handling** - Display API errors
- ✅ **Loading States** - User feedback during requests
- ✅ **Responsive Design** - Mobile-friendly interface

## API Configuration

The frontend is configured to connect to the backend API at:
```
http://localhost:5052/api
```

To change the API URL, update the fetch calls in the component files.