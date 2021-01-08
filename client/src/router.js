import { createRouter, createWebHashHistory } from 'vue-router'
// import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/vaults',
    name: 'Vaults',
    component: loadPage('VaultsPage')
    // beforeEnter: authGuard

  },
  {
    path: '/vaults/:vaultId',
    name: 'ActiveVault',
    component: loadPage('ActiveVaultPage')
    // beforeEnter: authGuard

  },
  {
    path: '/keeps/:keepId',
    name: 'ActiveKeepPage',
    component: loadPage('ActiveKeepPage')
  },
  {
    path: '/profile/:profileId',
    name: 'Profile',
    component: loadPage('ProfilePage')
    // beforeEnter: authGuard
  }
]

const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})

export default router
