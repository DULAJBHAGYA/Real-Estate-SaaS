#!/bin/bash

# Real Estate SaaS - Development Startup Script
echo "🚀 Starting Real Estate SaaS Development Environment..."

# Function to cleanup background processes on exit
cleanup() {
    echo "🛑 Stopping all services..."
    kill $(jobs -p) 2>/dev/null
    exit
}

# Set up cleanup on script exit
trap cleanup EXIT INT TERM

# Start backend server
echo "📡 Starting .NET Backend Server..."
cd server/RealEstateAPI && dotnet run &
BACKEND_PID=$!

# Wait a moment for backend to start
sleep 3

# Start frontend server
echo "🌐 Starting Next.js Frontend Server..."
cd ../client && npm run dev &
FRONTEND_PID=$!

echo "✅ Both servers are starting..."
echo "📡 Backend: http://localhost:5052"
echo "🌐 Frontend: http://localhost:3000"
echo ""
echo "Press Ctrl+C to stop all services"

# Wait for both processes
wait
