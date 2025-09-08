import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  // Set the correct workspace root to avoid lockfile warnings
  outputFileTracingRoot: '../',
  
  // Enable experimental features if needed
  experimental: {
    // Add any experimental features here
  },
  
  // Configure images if needed
  images: {
    domains: ['localhost'],
  },
};

export default nextConfig;
