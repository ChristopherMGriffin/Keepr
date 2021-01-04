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

  async addToVault(vId, kId) {
    try {
      const newVk = {
        VaultId: vId,
        KeepId: kId
      }
      const res = await api.post('api/vaultproducts', newVk)
      logger.log('w.s.', res.data)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const vaultService = new VaultService()
