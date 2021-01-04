<template>
  <div class="keep col-sm-6 col-md-4 col-lg-3 mt-2">
    <a href="#"
       @click="getOne(kprops.id)"
       data-toggle="modal"
       :data-target="'#modelId' + kprops.id"
    >
      <img
        class="img-thumbnail"
        style="width: 300px; height: 300px"
        :src="kprops.image"
        alt="Card image cap"
      >
    </a>
  </div>
  <div :id="'modelId' + kprops.id"
       class="modal fade bd-example-modal-lg"
       tabindex="-1"
       role="dialog"
       aria-labelledby="myLargeModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-lg">
      <div class="modal-content ">
        <div class="modal-body p-2">
          <div class="container-fluid ">
            <div class="row">
              <div class="col-5 ">
                <div class="row">
                  <img id="modal-image" :src="kprops.image" alt="">
                </div>
              </div>
              <div class="col-7">
                <div class="row">
                  <div class="col-12">
                    <button type="button" class="close btn btn-lg" data-dismiss="modal" aria-label="Close">
                      <span class="text-danger" aria-hidden="true">&times;</span>
                    </button>
                  </div>
                </div>
                <div class="row">
                  <transition-group class="route-enter-active">
                    <div class="pr-2 col-4 d-flex justify-content-end">
                      <p class="fade.in">
                        <i class="fas fa-eye    "></i>
                        {{ active.views }}
                      </p>
                    </div>
                    <div class="col-3">
                      <p>
                        <img class="pl-4 clr center pb-1"
                             src="../assets/img/klogo.png"
                             height="20"
                        />
                        {{ active.keepCount }}
                      </p>
                    </div>
                    <div class="col-3 pl-0">
                      <p class="">
                        <i class="fas fa-project-diagram"></i>
                        {{ active.shares }}
                      </p>
                    </div>
                  </transition-group>
                </div>
                <div class="mb-3 header">
                  <div class="row">
                    <div class="ml-2 col-12">
                      <h1>{{ kprops.name }}</h1>
                    </div>
                  </div>
                </div>
                <div class="row" id="modal-description">
                  <div class="col-12">
                    <p>{{ kprops.description }}</p>
                  </div>
                </div>
                <div class="row border-top border-dark mt-3 justify-content-center mr-1">
                  <div class="p-1 col-12">
                    <button class="btn btn-link">
                      tag 1
                    </button>
                    <button class="btn btn-link">
                      tag 2
                    </button>
                    <button class="btn btn-link">
                      tag 3
                    </button>
                    <button class="btn btn-link">
                      tag 4
                    </button>
                    <button class="btn btn-link">
                      tag 5
                    </button>
                    <button class="btn btn-link">
                      tag 6
                    </button>
                  </div>
                </div>
                <div class="row  pl-0 justify-content-space-between">
                  <div class="col-3 pl-1">
                    <div class="container">
                      <button id="vaultdoor" class="btn border rounded dropdown-toggle" type="button" data-toggle="dropdown">
                        ADD TO VAULT
                        <span class="caret"></span>
                      </button>
                      <div class="dropup">
                        <ul class="dropdown-menu row">
                          <li><button class="col-12 btn btn-block btn-link">Create New Vault</button></li>
                          <li><a href="#">CSS</a></li>
                          <li><a href="#">JavaScript</a></li>
                          <li class="divider"></li>
                          <li><a href="#">About Us</a></li>
                        </ul>
                      </div>
                    </div>
                    <!-- </div> -->
                  </div>
                  <div class="col pt-2">
                    <i id="trash" class="fas fa-trash fa-lg"></i>
                  </div>
                  <div class="col">
                    <span>
                      <img
                        :src="kprops.creator.picture"
                        alt="user photo"
                        height="40"
                        class="rounded"
                      />
                    </span>
                  </div>
                </div>
              </div>
            <!-- <div class="row">
              <div class="col-md-3 ml-auto">
                .col-md-3 .ml-auto
              </div>
              <div class="col-md-2 ml-auto">
                .col-md-2 .ml-auto
              </div>
            </div>
            <div class="row">
              <div class="col-md-6 ml-auto">
                .col-md-6 .ml-auto
              </div>
            </div>
            <div class="row">
              <div class="col-sm-9">
                Level 1: .col-sm-9
                <div class="row">
                  <div class="col-8 col-sm-6">
                    Level 2: .col-8 .col-sm-6
                  </div>
                  <div class="col-4 col-sm-6">
                    Level 2: .col-4 .col-sm-6
                  </div>
                </div>
              </div>
            </div> -->
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- Button trigger modal -->
    <!-- <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#modelId">
          Launch
        </button> -->

    <!-- Modal -->
    <!-- <div class="modal fade"
       :id="'modelId' + kprops.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            {{ kprops.id }}
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            Add rows here
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">
            Save
          </button>
        </div>
      </div>
    </div> -->
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
export default {
  name: 'Keep',
  props: ['kprops'],
  setup(props) {
    const state = reactive({
      editedKeep: {}
    })
    return {
      state,
      user: computed(() => AppState.user),
      profile: computed(() => AppState.profile),
      active: computed(() => AppState.activeKeep),
      deleteKeep(id) {
        keepService.deleteKeep(id)
      },
      editKeep(editedKeep) {
        keepService.editKeep(editedKeep)
      },
      getOne(id) {
        keepService.getOne(id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
#modal-image {
  max-width: 20em;
  max-height: 30em;
}

i {
  color:#55efc4 ;
}

.clr {
  color:#55efc4 ;

}
#modal-description {
  max-height: 15em;
  overflow-y: auto;
}
#trash {
  color: gray;
}
#vaultdoor {
  color: #55efc4;

}

// #modelId+kprops.id {
//   max-height: 50em;
// }

</style>
