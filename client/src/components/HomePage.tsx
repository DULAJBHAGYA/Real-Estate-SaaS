'use client';

import { useState, useEffect } from 'react';

interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  createdAt: string;
  isActive: boolean;
}

interface HomePageProps {
  user: User;
  onLogout: () => void;
}

export default function HomePage({ user, onLogout }: HomePageProps) {
  const [isLoggingOut, setIsLoggingOut] = useState(false);
  const [isClient, setIsClient] = useState(false);

  useEffect(() => {
    setIsClient(true);
  }, []);

  const handleLogout = async () => {
    setIsLoggingOut(true);
    
    try {
      const token = localStorage.getItem('jwtToken');
      
      // Call logout endpoint
      await fetch('http://localhost:5052/api/auth/logout', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({ token })
      });
    } catch (error) {
      console.error('Logout API call failed:', error);
    } finally {
      // Always logout locally regardless of API response
      onLogout();
      setIsLoggingOut(false);
    }
  };

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const monthNames = [
      'January', 'February', 'March', 'April', 'May', 'June',
      'July', 'August', 'September', 'October', 'November', 'December'
    ];
    const month = monthNames[date.getMonth()];
    const day = date.getDate();
    return `${month} ${day}, ${year}`;
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-slate-900 via-purple-900 to-slate-900">
      {/* Header */}
      <header className="bg-white/10 backdrop-blur-lg border-b border-white/20 sticky top-0 z-50">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between items-center py-6">
            <div className="flex items-center space-x-4">
              <div className="w-10 h-10 bg-gradient-to-r from-blue-500 to-purple-600 rounded-xl flex items-center justify-center">
                <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M3 7v10a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2H5a2 2 0 00-2-2z" />
                </svg>
              </div>
              <div>
                <h1 className="text-2xl font-bold text-white">Real Estate SaaS</h1>
                <p className="text-gray-300 text-sm">Welcome to your dashboard</p>
              </div>
            </div>
            <button
              onClick={handleLogout}
              disabled={isLoggingOut}
              className="bg-red-500/20 hover:bg-red-500/30 text-red-300 hover:text-red-200 px-6 py-2 rounded-xl text-sm font-semibold transition-all duration-200 border border-red-500/30 hover:border-red-500/50 disabled:opacity-50 disabled:cursor-not-allowed backdrop-blur-sm"
            >
              {isLoggingOut ? (
                <div className="flex items-center">
                  <svg className="animate-spin -ml-1 mr-2 h-4 w-4" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                    <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                    <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                  </svg>
                  Logging out...
                </div>
              ) : (
                'Logout'
              )}
            </button>
          </div>
        </div>
      </header>

      {/* Main Content */}
      <main className="max-w-7xl mx-auto py-8 sm:px-6 lg:px-8">
        <div className="px-4 py-6 sm:px-0">
          {/* Welcome Card */}
          <div className="bg-white/10 backdrop-blur-lg overflow-hidden shadow-2xl rounded-2xl mb-8 border border-white/20">
            <div className="px-6 py-8 sm:p-8">
              <div className="flex items-center mb-6">
                <div className="w-12 h-12 bg-gradient-to-r from-blue-500 to-purple-600 rounded-xl flex items-center justify-center mr-4">
                  <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                  </svg>
                </div>
                <div>
                  <h2 className="text-3xl font-bold text-white mb-2">
                    Welcome back, {user.firstName}! 👋
                  </h2>
                  <p className="text-gray-300">
                    You have successfully logged into the Real Estate SaaS platform.
                  </p>
                </div>
              </div>
              
              {/* User Info Card */}
              <div className="bg-white/5 backdrop-blur-sm rounded-xl p-6 border border-white/10">
                <h3 className="text-xl font-semibold text-white mb-6 flex items-center">
                  <svg className="w-5 h-5 mr-2 text-blue-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                  Your Account Information
                </h3>
                <dl className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-4">
                  <div className="space-y-2">
                    <dt className="text-sm font-medium text-gray-400">Full Name</dt>
                    <dd className="text-lg font-semibold text-white">
                      {user.firstName} {user.lastName}
                    </dd>
                  </div>
                  <div className="space-y-2">
                    <dt className="text-sm font-medium text-gray-400">Email Address</dt>
                    <dd className="text-lg font-semibold text-white break-all">{user.email}</dd>
                  </div>
                  <div className="space-y-2">
                    <dt className="text-sm font-medium text-gray-400">Account Status</dt>
                    <dd className="mt-1">
                      <span className={`inline-flex px-3 py-1 text-sm font-semibold rounded-full ${
                        user.isActive 
                          ? 'bg-green-500/20 text-green-300 border border-green-500/30' 
                          : 'bg-red-500/20 text-red-300 border border-red-500/30'
                      }`}>
                        {user.isActive ? '✓ Active' : '✗ Inactive'}
                      </span>
                    </dd>
                  </div>
                  <div className="space-y-2">
                    <dt className="text-sm font-medium text-gray-400">Member Since</dt>
                    <dd className="text-lg font-semibold text-white">
                      {isClient ? formatDate(user.createdAt) : 'Loading...'}
                    </dd>
                  </div>
                </dl>
              </div>
            </div>
          </div>

          {/* Features Grid */}
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 mb-8">
            <div className="bg-white/10 backdrop-blur-lg overflow-hidden shadow-xl rounded-2xl border border-white/20 hover:bg-white/15 transition-all duration-300 group">
              <div className="p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0">
                    <div className="w-12 h-12 bg-gradient-to-r from-blue-500 to-blue-600 rounded-xl flex items-center justify-center group-hover:scale-110 transition-transform duration-300">
                      <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M3 7v10a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2H5a2 2 0 00-2-2z" />
                      </svg>
                    </div>
                  </div>
                  <div className="ml-4 flex-1">
                    <dl>
                      <dt className="text-sm font-medium text-gray-400 truncate">Properties</dt>
                      <dd className="text-2xl font-bold text-white">0</dd>
                      <dd className="text-xs text-gray-500">Total listings</dd>
                    </dl>
                  </div>
                </div>
              </div>
            </div>

            <div className="bg-white/10 backdrop-blur-lg overflow-hidden shadow-xl rounded-2xl border border-white/20 hover:bg-white/15 transition-all duration-300 group">
              <div className="p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0">
                    <div className="w-12 h-12 bg-gradient-to-r from-green-500 to-green-600 rounded-xl flex items-center justify-center group-hover:scale-110 transition-transform duration-300">
                      <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                      </svg>
                    </div>
                  </div>
                  <div className="ml-4 flex-1">
                    <dl>
                      <dt className="text-sm font-medium text-gray-400 truncate">Bookings</dt>
                      <dd className="text-2xl font-bold text-white">0</dd>
                      <dd className="text-xs text-gray-500">Appointments</dd>
                    </dl>
                  </div>
                </div>
              </div>
            </div>

            <div className="bg-white/10 backdrop-blur-lg overflow-hidden shadow-xl rounded-2xl border border-white/20 hover:bg-white/15 transition-all duration-300 group">
              <div className="p-6">
                <div className="flex items-center">
                  <div className="flex-shrink-0">
                    <div className="w-12 h-12 bg-gradient-to-r from-purple-500 to-purple-600 rounded-xl flex items-center justify-center group-hover:scale-110 transition-transform duration-300">
                      <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
                      </svg>
                    </div>
                  </div>
                  <div className="ml-4 flex-1">
                    <dl>
                      <dt className="text-sm font-medium text-gray-400 truncate">Analytics</dt>
                      <dd className="text-2xl font-bold text-white">Soon</dd>
                      <dd className="text-xs text-gray-500">Coming soon</dd>
                    </dl>
                  </div>
                </div>
              </div>
            </div>
          </div>

          {/* API Test Section */}
          <div className="bg-white/10 backdrop-blur-lg overflow-hidden shadow-xl rounded-2xl border border-white/20">
            <div className="px-6 py-8 sm:p-8">
              <h3 className="text-xl font-semibold text-white mb-6 flex items-center">
                <svg className="w-5 h-5 mr-2 text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
                System Status
              </h3>
              <div className="grid grid-cols-1 sm:grid-cols-3 gap-6">
                <div className="bg-white/5 backdrop-blur-sm rounded-xl p-6 border border-white/10">
                  <div className="flex items-center mb-3">
                    <div className="w-3 h-3 bg-green-400 rounded-full mr-3 animate-pulse"></div>
                    <h4 className="text-lg font-semibold text-white">Authentication API</h4>
                  </div>
                  <p className="text-sm text-gray-300">Register, Login, Logout endpoints working perfectly</p>
                </div>
                <div className="bg-white/5 backdrop-blur-sm rounded-xl p-6 border border-white/10">
                  <div className="flex items-center mb-3">
                    <div className="w-3 h-3 bg-yellow-400 rounded-full mr-3 animate-pulse"></div>
                    <h4 className="text-lg font-semibold text-white">Backend Server</h4>
                  </div>
                  <p className="text-sm text-gray-300">Running on http://localhost:5052</p>
                </div>
                <div className="bg-white/5 backdrop-blur-sm rounded-xl p-6 border border-white/10">
                  <div className="flex items-center mb-3">
                    <div className="w-3 h-3 bg-blue-400 rounded-full mr-3 animate-pulse"></div>
                    <h4 className="text-lg font-semibold text-white">Frontend Client</h4>
                  </div>
                  <p className="text-sm text-gray-300">Next.js with Tailwind CSS</p>
                </div>
              </div>
            </div>
          </div>

          {/* Footer */}
          <footer className="mt-12 text-center">
            <div className="bg-white/5 backdrop-blur-sm rounded-2xl p-6 border border-white/10">
              <p className="text-gray-400 text-sm">
                © 2024 Real Estate SaaS. Built with Next.js, Tailwind CSS, and .NET 9.
              </p>
              <p className="text-gray-500 text-xs mt-2">
                This is a demo application showcasing modern web development practices.
              </p>
            </div>
          </footer>
        </div>
      </main>
    </div>
  );
}
