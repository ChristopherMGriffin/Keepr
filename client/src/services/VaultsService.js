import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
import { AppState } from '../AppState'

class VaultService {
  async createVault(nw) {
    try {
      const res = await api.post('api/vaults', nw)
      logger.log('fe service', res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      AppState.vaults = res.data
      logger.log('ws', res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      this.getVaultKeeps(id)
      AppState.activeVault = res.data
      logger.log('getOneVault', AppState.activeVault)
    } catch (e) {
      logger.log(e)
    }
  }

  async getVaultKeeps(id) {
    try {
      const res = await api.get('api/vaults/' + id + '/keeps')
      AppState.activeVaultKeeps = res.data
      logger.log('getvaultkeeps', AppState.activeVaultKeeps)
    } catch (e) {
      logger.log(e)
    }
  }

  async addToVault(vId) {
    try {
      const newVk = {
        VaultId: vId,
        KeepId: AppState.activeKeep.id
      }
      const res = await api.post('api/vaultkeeps', newVk)
      logger.log('w.s.', res.data)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const vaultService = new VaultService()
