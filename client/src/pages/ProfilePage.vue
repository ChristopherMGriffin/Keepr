<template>
  <div class="Profile container-fluid p-5">
    <div class="row">
      <div class="col-4">
        <img class="img-thumbnail rounded pic" :src="profile.picture" alt="">
      </div>
      <div class="col-7">
        <div class="row">
          <h1>{{ profile.name }}</h1>
          <div class="col-12">
            <h2>Vaults:  {{ profileVaults.length }}</h2>
          </div>
          <div class="col-12">
            <h2>Keeps:  {{ keeps.length }}</h2>
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-5">
      <h1 class="subheader ml-4">
        Vaults
      </h1><button class="btn btn-sm btn-link">
        <h1>+</h1>
      </button>
    </div>
    <div id="vault-row" class="d-flex h100">
      <VaultComponent v-for="v in profileVaults" :key="v.id" :vprops="v" />
    </div>
    <div class="row mt-5">
      <h1 class="subheader ml-4">
        Keeps
      </h1><button class="btn btn-sm btn-link">
        <h1>+</h1>
      </button>
      <div class="card-columns p-3">
        <Keep v-for="keep in keeps" :key="keep.id" :kprops="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import { VaultComponent } from '../components/VaultComponent'
import { logger } from '../utils/Logger'
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { profileService } from '../services/ProfileService'
import { useRoute } from 'vue-router'
export default {
  name: 'Profile',
  props: ['kprops', 'vprops'],
  components: { VaultComponent },
  setup(props) {
    const route = useRoute()
    onMounted(() => {
      profileService.getOneProfile(route.params.profileId)
      profileService.getProfileVaults(route.params.profileId)
      profileService.getProfileKeeps(route.params.profileId)
      logger.log('params', route.params.profileId)
    })
    return {
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults)

    }
  }
}
</script>

<style scoped>
img {
  max-width: 500px;
}
h1 {
  font-size: 5em;
}
#vault-row {
  white-space: nowrap;
  overflow-x: auto;
}
.pic {
width: 100%;
}
#plus {
  color:#55efc4
}
@media (min-width: 12em) {
    .card-columns {
        -webkit-column-count: 2;
        -moz-column-count: 2;
        column-count: 2;
    }
}

@media (min-width: 48em) {
    .card-columns {
        -webkit-column-count: 3;
        -moz-column-count: 3;
        column-count: 3;
    }
}

@media (min-width: 62em) {
    .card-columns {
        -webkit-column-count: 4;
        -moz-column-count: 4;
        column-count: 4;
    }
}

@media (min-width: 75em) {
    .card-columns {
        -webkit-column-count: 5;
        -moz-column-count: 5;
        column-count: 5;
    }
}
</style>
