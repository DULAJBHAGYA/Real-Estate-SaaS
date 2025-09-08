'use client';

import { useState } from 'react';
import LoginForm from '@/components/LoginForm';
import RegisterForm from '@/components/RegisterForm';
import HomePage from '@/components/HomePage';
import { useAuth } from '@/hooks/useAuth';
import type { User } from '@/hooks/useAuth';

export default function MainPage() {
  const [showLogin, setShowLogin] = useState(true);
  const { isAuthenticated, user, isLoading, login, logout } = useAuth();

  const handleLogin = (userData: User, token: string) => {
    login(userData, token);
  };

  const handleLogout = () => {
    logout();
  };

  if (isLoading) {
    return (
      <div className="min-h-screen bg-gradient-to-br from-slate-900 via-purple-900 to-slate-900 flex items-center justify-center">
        <div className="text-center">
          <div className="w-16 h-16 bg-gradient-to-r from-blue-500 to-purple-600 rounded-2xl mx-auto mb-4 animate-pulse"></div>
          <p className="text-white text-lg">Loading...</p>
        </div>
      </div>
    );
  }

  if (isAuthenticated && user) {
    return <HomePage user={user} onLogout={handleLogout} />;
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-slate-900 via-purple-900 to-slate-900 flex items-center justify-center p-4 relative overflow-hidden">
      {/* Background Pattern */}
      <div className="absolute inset-0 bg-[url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNjAiIGhlaWdodD0iNjAiIHZpZXdCb3g9IjAgMCA2MCA2MCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPjxnIGZpbGw9IiM5QzkyQUMiIGZpbGwtb3BhY2l0eT0iMC4xIj48Y2lyY2xlIGN4PSIzMCIgY3k9IjMwIiByPSIyIi8+PC9nPjwvZz48L3N2Zz4=')] opacity-20"></div>
      
      {/* Floating Elements */}
      <div className="absolute top-20 left-10 w-20 h-20 bg-blue-500/20 rounded-full blur-xl animate-float"></div>
      <div className="absolute bottom-20 right-10 w-32 h-32 bg-purple-500/20 rounded-full blur-xl animate-float-delayed"></div>
      <div className="absolute top-1/2 left-1/4 w-16 h-16 bg-pink-500/20 rounded-full blur-lg animate-float"></div>

      <div className="max-w-md w-full space-y-8 relative z-10 animate-fade-in">
        <div className="text-center animate-slide-up">
          <div className="inline-flex items-center justify-center w-16 h-16 bg-gradient-to-r from-blue-500 to-purple-600 rounded-2xl mb-6 shadow-lg animate-glow">
            <svg className="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M3 7v10a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2H5a2 2 0 00-2-2z" />
            </svg>
          </div>
          <h1 className="text-5xl font-bold bg-gradient-to-r from-white to-blue-200 bg-clip-text text-transparent mb-4">
            Real Estate SaaS
          </h1>
          <p className="text-gray-300 text-lg">
            {showLogin ? 'Welcome back! Please sign in to continue.' : 'Create your account to get started with our platform.'}
          </p>
        </div>

        <div className="bg-white/10 backdrop-blur-lg rounded-2xl shadow-2xl p-8 border border-white/20 animate-slide-up">
          <div className="flex mb-8 bg-gray-100/10 rounded-xl p-1">
            <button
              onClick={() => setShowLogin(true)}
              className={`flex-1 py-3 px-6 text-sm font-semibold rounded-lg transition-all duration-300 ${
                showLogin
                  ? 'bg-white text-gray-900 shadow-lg transform scale-105'
                  : 'text-gray-300 hover:text-white hover:bg-white/10'
              }`}
            >
              Sign In
            </button>
            <button
              onClick={() => setShowLogin(false)}
              className={`flex-1 py-3 px-6 text-sm font-semibold rounded-lg transition-all duration-300 ${
                !showLogin
                  ? 'bg-white text-gray-900 shadow-lg transform scale-105'
                  : 'text-gray-300 hover:text-white hover:bg-white/10'
              }`}
            >
              Sign Up
            </button>
          </div>

          <div className="transition-all duration-300 ease-in-out">
            {showLogin ? (
              <LoginForm onLogin={handleLogin} />
            ) : (
              <RegisterForm onRegister={handleLogin} />
            )}
          </div>
        </div>

        {/* Footer */}
        <div className="text-center text-gray-400 text-sm">
          <p>© 2024 Real Estate SaaS. All rights reserved.</p>
        </div>
      </div>
    </div>
  );
}