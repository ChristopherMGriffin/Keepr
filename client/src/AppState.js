import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  userProfile: {},
  publicKeeps: [],
  activeKeep: {},
  activeVault: {},
  userKeeps: [],
  userVaults: [],
  activeProfile: {},
  activeProfileVaults: [],
  activeProfileKeeps: [],
  activeVaultKeeps: []
})
