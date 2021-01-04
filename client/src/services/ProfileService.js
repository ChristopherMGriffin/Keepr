import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('api/profile')
      AppState.profile = res.data
      this.getProfileVaults()
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfileVaults() {
    try {
      var id = AppState.profile.id
      logger.log('profileId', id)
      const res = await api.get('api/profile/' + id + '/vaults')
      AppState.profile = res.data
      logger.log('profserv', AppState.vaults)
    } catch (e) {
      logger.log('Profile Service', e)
    }
  }
}

export const profileService = new ProfileService()
